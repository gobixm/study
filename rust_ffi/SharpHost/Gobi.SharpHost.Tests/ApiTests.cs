using System.Runtime.InteropServices;
using FluentAssertions;
using Gobi.SharpHost.Models;
using Xunit;

namespace Gobi.SharpHost.Tests
{
    public class ApiTests
    {
        [Fact]
        public void About_String_Returned()
        {
            // arrange

            // act
            var about = Api.About();

            // assert
            about.Should().Be("rust_ffi");
        }

        [Fact]
        public void IncrementFoo_Incremented_Returned()
        {
            // arrange
            var foo = new Foo
            {
                A = 1,
                B = 2,
                C = 3
            };

            // act
            var incremented = Api.IncrementFoo(foo, 1);

            // assert
            var expected = new Foo
            {
                A = 2,
                B = 3,
                C = 4
            };
            incremented.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Map_TransformedValue_Returned()
        {
            // arrange
            var source = 10;

            // act
            var mapped = Api.Map(source, x => -x);

            // assert
            mapped.Should().Be(-10);
        }
        
        [Fact]
        public void AllocateFoo_Foo_Returned()
        {
            // arrange
            var expectedFoo = new Foo
            {
                A = 1,
                B = 2,
                C = 3
            };
            
            // act
            var fooPtr = Api.AllocateFoo();

            // assert
            var foo = Marshal.PtrToStructure<Foo>(fooPtr);
            foo.Should().BeEquivalentTo(expectedFoo);
            Api.ReleaseFoo(fooPtr);
        }
        
        [Fact]
        public void FillFoo_Foo_Modified()
        {
            // arrange
            var foo = new Foo();
            var expectedFoo = new Foo
            {
                A = 11,
                B = 11,
                C = 11,
            };
            
            // act
            Api.FillFoo(ref foo, 11);

            // assert
            foo.Should().BeEquivalentTo(expectedFoo);
        }
    }
}