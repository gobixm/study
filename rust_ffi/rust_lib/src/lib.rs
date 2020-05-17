extern crate libc;

use std::ffi::CString;
use std::os::raw::c_char;

#[no_mangle]
pub extern fn about() -> *const c_char {
    let char_str = CString::new("rust_ffi").unwrap();
    let ptr = char_str.as_ptr();
    std::mem::forget(char_str);
    ptr
}

#[repr(C)]
pub struct Foo {
    a: i32,
    b: i32,
    c: i32,
}

#[no_mangle]
pub extern fn increment_foo(foo: Foo, add: i32) -> Foo {
    Foo {
        a: foo.a + add,
        b: foo.b + add,
        c: foo.c + add,
    }
}

#[no_mangle]
pub extern fn fill_foo(foo: *mut Foo, value: i32) {
    unsafe {
        (*foo).a = value;
        (*foo).b = value;
        (*foo).c = value;
    }
}

type Map = fn(i32) -> i32;

#[no_mangle]
pub extern fn map(v: i32, map: Map) -> i32 {
    map(v)
}

#[no_mangle]
pub extern fn allocate_foo() -> *mut Foo {
    let foo = Box::new(Foo {
        a: 1,
        b: 2,
        c: 3,
    });
    Box::into_raw(foo)
}

#[no_mangle]
pub extern fn release_foo(ptr: *mut Foo) {
    unsafe {
        Box::from_raw(ptr);
    }
}