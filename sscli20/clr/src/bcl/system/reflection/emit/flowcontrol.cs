/*============================================================
**
**Class: FlowControl
**
**Purpose: Exposes FlowControl Attribute of IL .
**
**
** Copyright (c) 2006 Microsoft Corporation.  All rights reserved.
**
** The use and distribution terms for this software are contained in the file
** named license.txt, which can be found in the root of this distribution.
** By using this software in any fashion, you are agreeing to be bound by the
** terms of this license.
**
** You must not remove this notice, or any other, from this software.
**
**
** THIS FILE IS AUTOMATICALLY GENERATED. DO NOT EDIT BY HAND!
** See clrsrcincopcodegen.pl for more information.**
============================================================*/
namespace System.Reflection.Emit {

using System;

[Serializable]
[System.Runtime.InteropServices.ComVisible(true)]
public enum FlowControl
{

	Branch	= 0,
	Break	= 1,
	Call	= 2,
	Cond_Branch	= 3,
	Meta	= 4,
	Next	= 5,
	/// <internalonly/>
	[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
	Phi	= 6,
	Return	= 7,
	Throw	= 8,
}
}
