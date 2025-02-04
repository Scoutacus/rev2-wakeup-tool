﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGXrdWakeupDPUtil.Library.Replay.AsmInjection
{
    [Flags]
    public enum MemoryProtectionFlags
    {
        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
        /// This value is not officially present in the Microsoft's enumeration but can occur according to the MEMORY_BASIC_INFORMATION structure documentation.
        /// </summary>
        ZeroAccess = 0,
        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to read from or write to the committed region results in an access violation.
        /// This flag is not supported by the CreateFileMapping function.
        /// </summary>
        Execute = 16, // 0x00000010
        /// <summary>
        /// Enables execute or read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// </summary>
        ExecuteRead = 32, // 0x00000020
        /// <summary>
        /// Enables execute, read-only, or read/write access to the committed region of pages.
        /// </summary>
        ExecuteReadWrite = 64, // 0x00000040
        /// <summary>
        /// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object.
        /// An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process.
        /// The private page is marked as PAGE_EXECUTE_READWRITE, and the change is written to the new page.
        /// This flag is not supported by the VirtualAlloc or <see cref="M:Binarysharp.MemoryManagement.Native.NativeMethods.VirtualAllocEx(Binarysharp.MemoryManagement.Native.SafeMemoryHandle,System.IntPtr,System.Int32,Binarysharp.MemoryManagement.Native.MemoryAllocationFlags,Binarysharp.MemoryManagement.Native.MemoryProtectionFlags)" /> functions.
        /// </summary>
        ExecuteWriteCopy = 128, // 0x00000080
        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
        /// This flag is not supported by the CreateFileMapping function.
        /// </summary>
        NoAccess = 1,
        /// <summary>
        /// Enables read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// If Data Execution Prevention is enabled, an attempt to execute code in the committed region results in an access violation.
        /// </summary>
        ReadOnly = 2,
        /// <summary>
        /// Enables read-only or read/write access to the committed region of pages.
        /// If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// </summary>
        ReadWrite = 4,
        /// <summary>
        /// Enables read-only or copy-on-write access to a mapped view of a file mapping object.
        /// An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process.
        /// The private page is marked as PAGE_READWRITE, and the change is written to the new page.
        /// If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// This flag is not supported by the VirtualAlloc or <see cref="M:Binarysharp.MemoryManagement.Native.NativeMethods.VirtualAllocEx(Binarysharp.MemoryManagement.Native.SafeMemoryHandle,System.IntPtr,System.Int32,Binarysharp.MemoryManagement.Native.MemoryAllocationFlags,Binarysharp.MemoryManagement.Native.MemoryProtectionFlags)" /> functions.
        /// </summary>
        WriteCopy = 8,
        /// <summary>
        /// Pages in the region become guard pages.
        /// Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status.
        /// Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.
        /// When an access attempt leads the system to turn off guard page status, the underlying page protection takes over.
        /// If a guard page exception occurs during a system service, the service typically returns a failure status indicator.
        /// This value cannot be used with PAGE_NOACCESS.
        /// This flag is not supported by the CreateFileMapping function.
        /// </summary>
        Guard = 256, // 0x00000100
        /// <summary>
        /// Sets all pages to be non-cachable. Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// The PAGE_NOCACHE flag cannot be used with the PAGE_GUARD, PAGE_NOACCESS, or PAGE_WRITECOMBINE flags.
        /// The PAGE_NOCACHE flag can be used only when allocating private memory with the VirtualAlloc, <see cref="M:Binarysharp.MemoryManagement.Native.NativeMethods.VirtualAllocEx(Binarysharp.MemoryManagement.Native.SafeMemoryHandle,System.IntPtr,System.Int32,Binarysharp.MemoryManagement.Native.MemoryAllocationFlags,Binarysharp.MemoryManagement.Native.MemoryProtectionFlags)" />, or VirtualAllocExNuma functions.
        /// To enable non-cached memory access for shared memory, specify the SEC_NOCACHE flag when calling the CreateFileMapping function.
        /// </summary>
        NoCache = 512, // 0x00000200
        /// <summary>
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped as write-combined can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// The PAGE_WRITECOMBINE flag cannot be specified with the PAGE_NOACCESS, PAGE_GUARD, and PAGE_NOCACHE flags.
        /// The PAGE_WRITECOMBINE flag can be used only when allocating private memory with the VirtualAlloc, <see cref="M:Binarysharp.MemoryManagement.Native.NativeMethods.VirtualAllocEx(Binarysharp.MemoryManagement.Native.SafeMemoryHandle,System.IntPtr,System.Int32,Binarysharp.MemoryManagement.Native.MemoryAllocationFlags,Binarysharp.MemoryManagement.Native.MemoryProtectionFlags)" />, or VirtualAllocExNuma functions.
        /// To enable write-combined memory access for shared memory, specify the SEC_WRITECOMBINE flag when calling the CreateFileMapping function.
        /// </summary>
        WriteCombine = 1024, // 0x00000400
    }
}
