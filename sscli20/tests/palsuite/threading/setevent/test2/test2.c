/*=============================================================================
**
** Source: test2.c
**
** Dependencies: PAL_Initialize
**               PAL_Terminate
**               CreateEvent
**               CloseHandle
**               WaitForSingleObject
**
** Purpose:
**
** Test to ensure proper operation of the SetEvent()
** API by calling it on an event handle that's already set.
** 
** 
**  Copyright (c) 2006 Microsoft Corporation.  All rights reserved.
** 
**  The use and distribution terms for this software are contained in the file
**  named license.txt, which can be found in the root of this distribution.
**  By using this software in any fashion, you are agreeing to be bound by the
**  terms of this license.
** 
**  You must not remove this notice, or any other, from this software.
** 
**
**===========================================================================*/
#include <palsuite.h>



int __cdecl main( int argc, char **argv ) 

{
    /* local variables */
    DWORD                   dwRet = 0;
    HANDLE                  hEvent = NULL;
    LPSECURITY_ATTRIBUTES   lpEventAttributes = NULL;
    BOOL                    bManualReset = TRUE; 
    BOOL                    bInitialState = FALSE;
    LPCTSTR                 lpName = "WooBaby";


    /* PAL initialization */
    if( (PAL_Initialize(argc, argv)) != 0 )
    {
        return( FAIL );
    }


    /* create an event which we can use with SetEvent */
    hEvent = CreateEvent(   lpEventAttributes, 
                            bManualReset,
                            bInitialState,
                            lpName );

    if( hEvent == INVALID_HANDLE_VALUE )
    {
        /* ERROR */
        Fail( "ERROR:%lu:CreateEvent() call failed\n", GetLastError() );
    }
    
    /* verify that the event isn't signalled yet */
    dwRet = WaitForSingleObject( hEvent, 0 );
    if( dwRet != WAIT_TIMEOUT )
    {
        /* ERROR */
        Trace( "ERROR:WaitForSingleObject() call returned %lu, "
                "expected WAIT_TIMEOUT\n",
                dwRet );
        CloseHandle( hEvent );
        Fail( "Test failed\n" );
    }
    
    /* set the event */
    if( ! SetEvent( hEvent ) )
    {
        /* ERROR */
        Trace( "ERROR:%lu:SetEvent() call failed\n", GetLastError() );
        CloseHandle( hEvent );
        Fail( "Test failed\n" );
    }
    
    /* verify that the event is signalled */
    dwRet = WaitForSingleObject( hEvent, 0 );
    if( dwRet != WAIT_OBJECT_0 )
    {
        /* ERROR */
        Trace( "ERROR:WaitForSingleObject() call returned %lu, "
                "expected WAIT_OBJECT_0\n",
                dwRet );
        CloseHandle( hEvent );
        Fail( "Test failed\n" );
    }
    
    /* try to set the event again */
    if( ! SetEvent( hEvent ) )
    {
        /* ERROR */
        Trace( "FAIL:%lu:SetEvent() call failed on signalled event\n",
                GetLastError() );
        CloseHandle( hEvent );
        Fail( "Test failed\n" );
    }
    
    /* verify that the event is still signalled */
    dwRet = WaitForSingleObject( hEvent, 0 );
    if( dwRet != WAIT_OBJECT_0 )
    {
        /* ERROR */
        Trace( "ERROR:WaitForSingleObject() call returned %lu, "
                "expected WAIT_OBJECT_0\n",
                dwRet );
        CloseHandle( hEvent );
        Fail( "Test failed\n" );
    }
    

    /* close the event handle */
    if( ! CloseHandle( hEvent ) )
    {
        Fail( "ERROR:%lu:CloseHandle() call failed\n", GetLastError() );
    }

    
    /* PAL termination */
    PAL_Terminate();
    
    /* return success */
    return PASS;
}
