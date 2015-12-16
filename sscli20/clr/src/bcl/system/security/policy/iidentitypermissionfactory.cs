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
//  IIdentityPermissionFactory.cs
//
//  All Identities will implement this interface.
//

namespace System.Security.Policy {
	using System.Runtime.Remoting;
	using System;
	using System.Security.Util;
[System.Runtime.InteropServices.ComVisible(true)]
    public interface IIdentityPermissionFactory
    {
        IPermission CreateIdentityPermission( Evidence evidence );
    }

}
