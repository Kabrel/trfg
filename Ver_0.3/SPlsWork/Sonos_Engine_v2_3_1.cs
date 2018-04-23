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
using SonosLibrary_v2_3;
using SonosProLibrary_v2_3;
using Crestron.AppHelperClassesv2_0;
using AppHelperClasses;
using Crestron.AppHelperClasses;
using Crestron.CRPC.CIPDirectTransport;
using Crestron.CRPC;
using Crestron.CRPC.Common;
using CRPCConnectionHelper;

namespace CrestronModule_SONOS_ENGINE_V2_3_1
{
    public class CrestronModuleClass_SONOS_ENGINE_V2_3_1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput PRINTTEST;
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput DISCOVERGROUPS;
        Crestron.Logos.SplusObjects.DigitalInput STOPDISCOVERY;
        Crestron.Logos.SplusObjects.DigitalInput PRINTLIST;
        Crestron.Logos.SplusObjects.DigitalInput GETFAVORITES;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEDEBUGMODE;
        Crestron.Logos.SplusObjects.DigitalInput DISABLEDEBUGMODE;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DISCOVERINGGROUPS_FB;
        Crestron.Logos.SplusObjects.DigitalOutput GETTINGFAVORITES_FB;
        SonosLibrary_v2_3.SystemDriver SIMPLSHARPSYSTEMDRIVER;
        private void REGISTERDELEGATES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 87;
            // RegisterDelegate( SIMPLSHARPSYSTEMDRIVER , PLAYERBUSYUPDATE , UPDATEBUSYSTATUS ) 
            SIMPLSHARPSYSTEMDRIVER .PlayerBusyUpdate  = UPDATEBUSYSTATUS; ; 
            
            }
            
        public void UPDATEBUSYSTATUS ( ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 92;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIMPLSHARPSYSTEMDRIVER.BusyStatus == "true"))  ) ) 
                    {
                    __context__.SourceCodeLine = 93;
                    BUSY_FB  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 95;
                    BUSY_FB  .Value = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 97;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIMPLSHARPSYSTEMDRIVER.DiscoveringGroups == "true"))  ) ) 
                    {
                    __context__.SourceCodeLine = 98;
                    DISCOVERINGGROUPS_FB  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 100;
                    DISCOVERINGGROUPS_FB  .Value = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 102;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIMPLSHARPSYSTEMDRIVER.GettingFavorites == "true"))  ) ) 
                    {
                    __context__.SourceCodeLine = 103;
                    GETTINGFAVORITES_FB  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 105;
                    GETTINGFAVORITES_FB  .Value = (ushort) ( 0 ) ; 
                    }
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object PRINTTEST_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 117;
                SIMPLSHARPSYSTEMDRIVER . PrintTest ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INITIALIZE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 122;
            SIMPLSHARPSYSTEMDRIVER . Initialize ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DISCOVERGROUPS_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 127;
        SIMPLSHARPSYSTEMDRIVER . DiscoverGroups ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STOPDISCOVERY_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 132;
        SIMPLSHARPSYSTEMDRIVER . StopDiscovery ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PRINTLIST_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 137;
        SIMPLSHARPSYSTEMDRIVER . PrintGroupTopology ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GETFAVORITES_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 142;
        SIMPLSHARPSYSTEMDRIVER . GetFavorites ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEDEBUGMODE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 147;
        SIMPLSHARPSYSTEMDRIVER . EnableLogger ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISABLEDEBUGMODE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 152;
        SIMPLSHARPSYSTEMDRIVER . DisableLogger ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 187;
        REGISTERDELEGATES (  __context__  ) ; 
        __context__.SourceCodeLine = 188;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    PRINTTEST = new Crestron.Logos.SplusObjects.DigitalInput( PRINTTEST__DigitalInput__, this );
    m_DigitalInputList.Add( PRINTTEST__DigitalInput__, PRINTTEST );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    DISCOVERGROUPS = new Crestron.Logos.SplusObjects.DigitalInput( DISCOVERGROUPS__DigitalInput__, this );
    m_DigitalInputList.Add( DISCOVERGROUPS__DigitalInput__, DISCOVERGROUPS );
    
    STOPDISCOVERY = new Crestron.Logos.SplusObjects.DigitalInput( STOPDISCOVERY__DigitalInput__, this );
    m_DigitalInputList.Add( STOPDISCOVERY__DigitalInput__, STOPDISCOVERY );
    
    PRINTLIST = new Crestron.Logos.SplusObjects.DigitalInput( PRINTLIST__DigitalInput__, this );
    m_DigitalInputList.Add( PRINTLIST__DigitalInput__, PRINTLIST );
    
    GETFAVORITES = new Crestron.Logos.SplusObjects.DigitalInput( GETFAVORITES__DigitalInput__, this );
    m_DigitalInputList.Add( GETFAVORITES__DigitalInput__, GETFAVORITES );
    
    ENABLEDEBUGMODE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEDEBUGMODE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEDEBUGMODE__DigitalInput__, ENABLEDEBUGMODE );
    
    DISABLEDEBUGMODE = new Crestron.Logos.SplusObjects.DigitalInput( DISABLEDEBUGMODE__DigitalInput__, this );
    m_DigitalInputList.Add( DISABLEDEBUGMODE__DigitalInput__, DISABLEDEBUGMODE );
    
    BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY_FB__DigitalOutput__, BUSY_FB );
    
    DISCOVERINGGROUPS_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DISCOVERINGGROUPS_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DISCOVERINGGROUPS_FB__DigitalOutput__, DISCOVERINGGROUPS_FB );
    
    GETTINGFAVORITES_FB = new Crestron.Logos.SplusObjects.DigitalOutput( GETTINGFAVORITES_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( GETTINGFAVORITES_FB__DigitalOutput__, GETTINGFAVORITES_FB );
    
    
    PRINTTEST.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRINTTEST_OnPush_0, false ) );
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_1, false ) );
    DISCOVERGROUPS.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISCOVERGROUPS_OnPush_2, false ) );
    STOPDISCOVERY.OnDigitalPush.Add( new InputChangeHandlerWrapper( STOPDISCOVERY_OnPush_3, false ) );
    PRINTLIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRINTLIST_OnPush_4, false ) );
    GETFAVORITES.OnDigitalPush.Add( new InputChangeHandlerWrapper( GETFAVORITES_OnPush_5, false ) );
    ENABLEDEBUGMODE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEDEBUGMODE_OnPush_6, false ) );
    DISABLEDEBUGMODE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISABLEDEBUGMODE_OnPush_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    SIMPLSHARPSYSTEMDRIVER  = new SonosLibrary_v2_3.SystemDriver();
    
    
}

public CrestronModuleClass_SONOS_ENGINE_V2_3_1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PRINTTEST__DigitalInput__ = 0;
const uint INITIALIZE__DigitalInput__ = 1;
const uint DISCOVERGROUPS__DigitalInput__ = 2;
const uint STOPDISCOVERY__DigitalInput__ = 3;
const uint PRINTLIST__DigitalInput__ = 4;
const uint GETFAVORITES__DigitalInput__ = 5;
const uint ENABLEDEBUGMODE__DigitalInput__ = 6;
const uint DISABLEDEBUGMODE__DigitalInput__ = 7;
const uint BUSY_FB__DigitalOutput__ = 0;
const uint DISCOVERINGGROUPS_FB__DigitalOutput__ = 1;
const uint GETTINGFAVORITES_FB__DigitalOutput__ = 2;

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
