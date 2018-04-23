using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using CrestronKNXLibrary.Communication;
using CrestronKNXLibrary.Routing;
using CrestronKNXLibrary.General;
using CrestronKNXLibrary.Data_Types;

namespace UserModule_CRESTRON_KNX_IO_V3_2
{
    public class UserModuleClass_CRESTRON_KNX_IO_V3_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput POLLALL;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEDEBUGMODE;
        Crestron.Logos.SplusObjects.DigitalOutput INITIALIZATIONISCOMPLETE;
        Crestron.Logos.SplusObjects.AnalogOutput CONNECTIONSTATUS;
        UShortParameter IPGATEWAYID;
        UShortParameter IPNETWERKPORT;
        UShortParameter GATEWAYTYPE;
        StringParameter SPIPADDRESS;
        CrestronKNXLibrary.Routing.KNXRouterSimplSharpComponent SIMPLSHARPCOMPONENT;
        object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 85;
                SIMPLSHARPCOMPONENT . InitializeSettings ( (int)( IPGATEWAYID  .Value ), (int)( GATEWAYTYPE  .Value ), GetSymbolReferenceName() .ToString(), SPIPADDRESS  .ToString(), (int)( IPNETWERKPORT  .Value )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object POLLALL_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 90;
            SIMPLSHARPCOMPONENT . PollAllAddresses ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ENABLEDEBUGMODE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 95;
        SIMPLSHARPCOMPONENT . ChangeDebugMode ( (int)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEDEBUGMODE_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 100;
        SIMPLSHARPCOMPONENT . ChangeDebugMode ( (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void UPDATECONNECTIONSTATUCALLBACK ( ushort VALUE ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 114;
        CONNECTIONSTATUS  .Value = (ushort) ( VALUE ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void INITIALIZATIONISCOMPLETECALLBACK ( ushort TEMPSTATE ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 119;
        INITIALIZATIONISCOMPLETE  .Value = (ushort) ( TEMPSTATE ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void BASICINITIALIZATIONISCOMPLETEHANDLER ( ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 126;
        // RegisterDelegate( SIMPLSHARPCOMPONENT , INITIALIZATIONISCOMPLETE , INITIALIZATIONISCOMPLETECALLBACK ) 
        SIMPLSHARPCOMPONENT .initializationIsComplete  = INITIALIZATIONISCOMPLETECALLBACK; ; 
        __context__.SourceCodeLine = 127;
        // RegisterDelegate( SIMPLSHARPCOMPONENT , UPDATECONNECTIONSTATUS , UPDATECONNECTIONSTATUCALLBACK ) 
        SIMPLSHARPCOMPONENT .UpdateConnectionStatus  = UPDATECONNECTIONSTATUCALLBACK; ; 
        __context__.SourceCodeLine = 129;
        SIMPLSHARPCOMPONENT . BeginInitialization ( ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 143;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 144;
        // RegisterDelegate( SIMPLSHARPCOMPONENT , BASICINITIALIZATIONISCOMPLETE , BASICINITIALIZATIONISCOMPLETEHANDLER ) 
        SIMPLSHARPCOMPONENT .basicInitializationIsComplete  = BASICINITIALIZATIONISCOMPLETEHANDLER; ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    POLLALL = new Crestron.Logos.SplusObjects.DigitalInput( POLLALL__DigitalInput__, this );
    m_DigitalInputList.Add( POLLALL__DigitalInput__, POLLALL );
    
    ENABLEDEBUGMODE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEDEBUGMODE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEDEBUGMODE__DigitalInput__, ENABLEDEBUGMODE );
    
    INITIALIZATIONISCOMPLETE = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZATIONISCOMPLETE__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZATIONISCOMPLETE__DigitalOutput__, INITIALIZATIONISCOMPLETE );
    
    CONNECTIONSTATUS = new Crestron.Logos.SplusObjects.AnalogOutput( CONNECTIONSTATUS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CONNECTIONSTATUS__AnalogSerialOutput__, CONNECTIONSTATUS );
    
    IPGATEWAYID = new UShortParameter( IPGATEWAYID__Parameter__, this );
    m_ParameterList.Add( IPGATEWAYID__Parameter__, IPGATEWAYID );
    
    IPNETWERKPORT = new UShortParameter( IPNETWERKPORT__Parameter__, this );
    m_ParameterList.Add( IPNETWERKPORT__Parameter__, IPNETWERKPORT );
    
    GATEWAYTYPE = new UShortParameter( GATEWAYTYPE__Parameter__, this );
    m_ParameterList.Add( GATEWAYTYPE__Parameter__, GATEWAYTYPE );
    
    SPIPADDRESS = new StringParameter( SPIPADDRESS__Parameter__, this );
    m_ParameterList.Add( SPIPADDRESS__Parameter__, SPIPADDRESS );
    
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    POLLALL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLLALL_OnPush_1, false ) );
    ENABLEDEBUGMODE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEDEBUGMODE_OnPush_2, false ) );
    ENABLEDEBUGMODE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLEDEBUGMODE_OnRelease_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    SIMPLSHARPCOMPONENT  = new CrestronKNXLibrary.Routing.KNXRouterSimplSharpComponent();
    
    
}

public UserModuleClass_CRESTRON_KNX_IO_V3_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint POLLALL__DigitalInput__ = 1;
const uint ENABLEDEBUGMODE__DigitalInput__ = 2;
const uint INITIALIZATIONISCOMPLETE__DigitalOutput__ = 0;
const uint CONNECTIONSTATUS__AnalogSerialOutput__ = 0;
const uint IPGATEWAYID__Parameter__ = 10;
const uint IPNETWERKPORT__Parameter__ = 11;
const uint GATEWAYTYPE__Parameter__ = 12;
const uint SPIPADDRESS__Parameter__ = 13;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
