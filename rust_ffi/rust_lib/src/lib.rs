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
    Foo{
        a: foo.a + add,
        b: foo.b + add,
        c: foo.c + add
    }
}

type Map = fn(i32) -> i32;

#[no_mangle]
pub extern fn map(v: i32, map: Map) -> i32 {
    map(v)
}