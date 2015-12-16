// ==++==
// 
//   
//    Copyright (c) 2006 Microsoft Corporation.  All rights reserved.
//   
//    The use and distribution terms for this software are contained in the file
//    named license.txt, which can be found in the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by the
//    terms of this license.
//   
//    You must not remove this notice, or any other, from this software.
//   
// 
// ==--==
/*============================================================
**
** Class:  ParseNumbers
**
**
** Purpose: Methods for Parsing numbers and Strings.
** All methods are implemented in native.
**
** 
===========================================================*/
namespace System {
   
    //This class contains only static members and does not need to be serializable.
	using System;
	using System.Runtime.CompilerServices;
    internal static class ParseNumbers {
        internal const int PrintAsI1=0x40;
        internal const int PrintAsI2=0x80;
        internal const int PrintAsI4=0x100;
        internal const int TreatAsUnsigned=0x200;
        internal const int TreatAsI1=0x400;
        internal const int TreatAsI2=0x800;
        internal const int IsTight=0x1000;
        internal const int NoSpace=0x2000;
      
        //
        //
        // NATIVE METHODS
        // For comments on these methods please see $\src\vm\COMUtilNative.cpp
        //
        public unsafe static long StringToLong(System.String s, int radix, int flags) {
            return StringToLong(s,radix,flags, null);
        }
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public unsafe extern static long StringToLong(System.String s, int radix, int flags, int* currPos);

        public unsafe static long StringToLong(System.String s, int radix, int flags, ref int currPos) {
            fixed(int * ppos = &currPos) {
                return StringToLong( s, radix, flags, ppos);
            }
        }
        
        public unsafe static int StringToInt(System.String s, int radix, int flags) {            
            return StringToInt(s,radix,flags, null);
        }
        [MethodImplAttribute(MethodImplOptions.InternalCall)]        
        public unsafe extern static int StringToInt(System.String s, int radix, int flags, int* currPos);        

        public unsafe static int StringToInt(System.String s, int radix, int flags, ref int currPos) {            
            fixed(int * ppos = &currPos) {
                return StringToInt( s, radix, flags, ppos);
            }
        }        
    
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static String IntToString(int l, int radix, int width, char paddingChar, int flags);

	    [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static String LongToString(long l, int radix, int width, char paddingChar, int flags);
    }
}
