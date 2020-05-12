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
