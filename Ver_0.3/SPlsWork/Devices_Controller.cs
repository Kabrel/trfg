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

namespace UserModule_DEVICES_CONTROLLER
{
    public class UserModuleClass_DEVICES_CONTROLLER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput DEVICE_DEFAULT_SELECT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ITEM_SELECT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ITEM_MATCHES;
        Crestron.Logos.SplusObjects.AnalogInput DEVICE_IS;
        Crestron.Logos.SplusObjects.AnalogInput DEVICE_DEFAULT;
        Crestron.Logos.SplusObjects.StringInput DEFAULT_AVAILABLE_DEVICES;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> DEVICE_ICON_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DEVICE_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DEVICE_DESCRIPTION_IS;
        Crestron.Logos.SplusObjects.AnalogOutput ITEMS_SIZE;
        Crestron.Logos.SplusObjects.StringOutput DEVICE_SET;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> ITEM_ICON_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> ITEM_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> ITEM_DESCRIPTION_IS;
        UShortParameter DEVICE_TYPE;
        StringParameter DEVICES;
        private ushort IDTOINDEX (  SplusExecutionContext __context__, ushort ID ) 
            { 
            ushort INDEX = 0;
            
            
            __context__.SourceCodeLine = 60;
            ID = (ushort) ( Functions.Low( (ushort) ID ) ) ; 
            __context__.SourceCodeLine = 61;
            INDEX = (ushort) ( Functions.Atoi( Functions.ItoHex( (int)( ID ) ) ) ) ; 
            __context__.SourceCodeLine = 63;
            return (ushort)( INDEX) ; 
            
            }
            
        private ushort INDEXTOID (  SplusExecutionContext __context__, ushort INDEX ) 
            { 
            ushort ID = 0;
            
            
            __context__.SourceCodeLine = 70;
            ID = (ushort) ( Functions.HextoI( Functions.ItoA( (int)( INDEX ) ) ) ) ; 
            __context__.SourceCodeLine = 72;
            return (ushort)( ID) ; 
            
            }
            
        CrestronString __DEVICES__;
        ushort [] __ITEM_DEVICE__;
        ushort [] __DEVICE_ITEM__;
        private ushort ITEMTODEVICE (  SplusExecutionContext __context__, ushort ITEM ) 
            { 
            ushort DEVICE = 0;
            
            
            __context__.SourceCodeLine = 86;
            DEVICE = (ushort) ( __ITEM_DEVICE__[ ITEM ] ) ; 
            __context__.SourceCodeLine = 88;
            return (ushort)( DEVICE) ; 
            
            }
            
        private ushort DEVICETOITEM (  SplusExecutionContext __context__, ushort DEVICE ) 
            { 
            ushort ITEM = 0;
            
            
            __context__.SourceCodeLine = 95;
            DEVICE = (ushort) ( Functions.Low( (ushort) DEVICE ) ) ; 
            __context__.SourceCodeLine = 97;
            ITEM = (ushort) ( __DEVICE_ITEM__[ DEVICE ] ) ; 
            __context__.SourceCodeLine = 99;
            /* Trace( "DeviceToItem({0:X2}) = {1:d}", DEVICE, (ushort)ITEM) */ ; 
            __context__.SourceCodeLine = 101;
            return (ushort)( ITEM) ; 
            
            }
            
        object ITEM_SELECT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort ITEM = 0;
                ushort DEVICE = 0;
                
                
                __context__.SourceCodeLine = 111;
                ITEM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 112;
                DEVICE = (ushort) ( ITEMTODEVICE( __context__ , (ushort)( ITEM ) ) ) ; 
                __context__.SourceCodeLine = 114;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 114;
                    Functions.TerminateEvent (); 
                    }
                
                __context__.SourceCodeLine = 116;
                MakeString ( DEVICE_SET , "{0}{1}", Functions.Chr ( (DEVICE_TYPE  .Value << 4) ) , Functions.Chr ( INDEXTOID( __context__ , (ushort)( DEVICE ) ) ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DEVICE_DEFAULT_SELECT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 121;
            MakeString ( DEVICE_SET , "{0}{1}", Functions.Chr ( (DEVICE_TYPE  .Value << 4) ) , Functions.Chr ( Functions.Low( (ushort) DEVICE_DEFAULT  .UshortValue ) ) ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
private void UPDATEITEMMATCHES (  SplusExecutionContext __context__ ) 
    { 
    ushort ITEM = 0;
    
    
    __context__.SourceCodeLine = 131;
    Functions.SetArray ( ITEM_MATCHES , (ushort)0) ; 
    __context__.SourceCodeLine = 133;
    ITEM = (ushort) ( DEVICETOITEM( __context__ , (ushort)( IDTOINDEX( __context__ , (ushort)( DEVICE_IS  .UshortValue ) ) ) ) ) ; 
    __context__.SourceCodeLine = 134;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEM == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 136;
        ITEM = (ushort) ( DEVICETOITEM( __context__ , (ushort)( IDTOINDEX( __context__ , (ushort)( DEVICE_DEFAULT  .UshortValue ) ) ) ) ) ; 
        __context__.SourceCodeLine = 138;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEM == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 140;
            return ; 
            } 
        
        } 
    
    __context__.SourceCodeLine = 144;
    ITEM_MATCHES [ ITEM]  .Value = (ushort) ( 1 ) ; 
    
    }
    
private void UPDATEITEMICON (  SplusExecutionContext __context__, ushort DEVICE ) 
    { 
    ushort ITEM = 0;
    
    
    __context__.SourceCodeLine = 151;
    ITEM = (ushort) ( DEVICETOITEM( __context__ , (ushort)( DEVICE ) ) ) ; 
    __context__.SourceCodeLine = 152;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEM == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 154;
        return ; 
        } 
    
    __context__.SourceCodeLine = 157;
    ITEM_ICON_IS [ ITEM]  .Value = (ushort) ( DEVICE_ICON_IS[ DEVICE ] .UshortValue ) ; 
    
    }
    
private void UPDATEITEMDESCRIPTION (  SplusExecutionContext __context__, ushort DEVICE ) 
    { 
    ushort ITEM = 0;
    
    
    __context__.SourceCodeLine = 164;
    ITEM = (ushort) ( DEVICETOITEM( __context__ , (ushort)( DEVICE ) ) ) ; 
    __context__.SourceCodeLine = 165;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEM == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 167;
        return ; 
        } 
    
    __context__.SourceCodeLine = 170;
    ITEM_DESCRIPTION_IS [ ITEM]  .UpdateValue ( DEVICE_DESCRIPTION_IS [ DEVICE ]  ) ; 
    
    }
    
private void UPDATELIST (  SplusExecutionContext __context__ ) 
    { 
    ushort I = 0;
    ushort ITEM = 0;
    ushort DEVICE = 0;
    
    
    __context__.SourceCodeLine = 177;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (__DEVICES__ == ""))  ) ) 
        { 
        __context__.SourceCodeLine = 179;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICES  != ""))  ) ) 
            { 
            __context__.SourceCodeLine = 181;
            __DEVICES__  .UpdateValue ( DEVICES  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 183;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEFAULT_AVAILABLE_DEVICES != ""))  ) ) 
                { 
                __context__.SourceCodeLine = 185;
                __DEVICES__  .UpdateValue ( DEFAULT_AVAILABLE_DEVICES  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 189;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)99; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 191;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_NAME_IS[ I ] != ""))  ) ) 
                        { 
                        __context__.SourceCodeLine = 193;
                        MakeString ( __DEVICES__ , "{0}{1}", __DEVICES__ , Functions.Chr ( INDEXTOID( __context__ , (ushort)( I ) ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 189;
                    } 
                
                } 
            
            }
        
        } 
    
    __context__.SourceCodeLine = 199;
    ITEMS_SIZE  .Value = (ushort) ( Functions.Length( __DEVICES__ ) ) ; 
    __context__.SourceCodeLine = 201;
    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__2 = (ushort)ITEMS_SIZE  .Value; 
    int __FN_FORSTEP_VAL__2 = (int)1; 
    for ( ITEM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (ITEM  >= __FN_FORSTART_VAL__2) && (ITEM  <= __FN_FOREND_VAL__2) ) : ( (ITEM  <= __FN_FORSTART_VAL__2) && (ITEM  >= __FN_FOREND_VAL__2) ) ; ITEM  += (ushort)__FN_FORSTEP_VAL__2) 
        { 
        __context__.SourceCodeLine = 203;
        DEVICE = (ushort) ( Byte( __DEVICES__ , (int)( ITEM ) ) ) ; 
        __context__.SourceCodeLine = 204;
        DEVICE = (ushort) ( IDTOINDEX( __context__ , (ushort)( DEVICE ) ) ) ; 
        __context__.SourceCodeLine = 206;
        __ITEM_DEVICE__ [ ITEM] = (ushort) ( DEVICE ) ; 
        __context__.SourceCodeLine = 207;
        __DEVICE_ITEM__ [ DEVICE] = (ushort) ( ITEM ) ; 
        __context__.SourceCodeLine = 209;
        ITEM_NAME_IS [ ITEM]  .UpdateValue ( DEVICE_NAME_IS [ DEVICE ]  ) ; 
        __context__.SourceCodeLine = 211;
        UPDATEITEMICON (  __context__ , (ushort)( DEVICE )) ; 
        __context__.SourceCodeLine = 212;
        UPDATEITEMDESCRIPTION (  __context__ , (ushort)( DEVICE )) ; 
        __context__.SourceCodeLine = 201;
        } 
    
    __context__.SourceCodeLine = 215;
    UPDATEITEMMATCHES (  __context__  ) ; 
    
    }
    
object DEVICE_IS_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 223;
        /* Trace( "CHANGE Device_Is") */ ; 
        __context__.SourceCodeLine = 224;
        UPDATEITEMMATCHES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEVICE_DEFAULT_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 229;
        /* Trace( "CHANGE Device_Default") */ ; 
        __context__.SourceCodeLine = 230;
        UPDATEITEMMATCHES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEVICE_ICON_IS_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort DEVICE = 0;
        
        
        __context__.SourceCodeLine = 237;
        DEVICE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 239;
        UPDATEITEMICON (  __context__ , (ushort)( DEVICE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEVICE_DESCRIPTION_IS_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort DEVICE = 0;
        
        
        __context__.SourceCodeLine = 246;
        DEVICE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 248;
        UPDATEITEMDESCRIPTION (  __context__ , (ushort)( DEVICE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void __INIT__ (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 256;
    __DEVICES__  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 258;
    Functions.SetArray (  ref __ITEM_DEVICE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 259;
    Functions.SetArray (  ref __DEVICE_ITEM__ , (ushort)0) ; 
    __context__.SourceCodeLine = 261;
    UPDATELIST (  __context__  ) ; 
    
    }
    
object INITIALIZE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 266;
        __INIT__ (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 274;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    __ITEM_DEVICE__  = new ushort[ 49 ];
    __DEVICE_ITEM__  = new ushort[ 100 ];
    __DEVICES__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 99, this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    DEVICE_DEFAULT_SELECT = new Crestron.Logos.SplusObjects.DigitalInput( DEVICE_DEFAULT_SELECT__DigitalInput__, this );
    m_DigitalInputList.Add( DEVICE_DEFAULT_SELECT__DigitalInput__, DEVICE_DEFAULT_SELECT );
    
    ITEM_SELECT = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        ITEM_SELECT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ITEM_SELECT__DigitalInput__ + i, ITEM_SELECT__DigitalInput__, this );
        m_DigitalInputList.Add( ITEM_SELECT__DigitalInput__ + i, ITEM_SELECT[i+1] );
    }
    
    ITEM_MATCHES = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        ITEM_MATCHES[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ITEM_MATCHES__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ITEM_MATCHES__DigitalOutput__ + i, ITEM_MATCHES[i+1] );
    }
    
    DEVICE_IS = new Crestron.Logos.SplusObjects.AnalogInput( DEVICE_IS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DEVICE_IS__AnalogSerialInput__, DEVICE_IS );
    
    DEVICE_DEFAULT = new Crestron.Logos.SplusObjects.AnalogInput( DEVICE_DEFAULT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DEVICE_DEFAULT__AnalogSerialInput__, DEVICE_DEFAULT );
    
    DEVICE_ICON_IS = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DEVICE_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( DEVICE_ICON_IS__AnalogSerialInput__ + i, DEVICE_ICON_IS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( DEVICE_ICON_IS__AnalogSerialInput__ + i, DEVICE_ICON_IS[i+1] );
    }
    
    ITEMS_SIZE = new Crestron.Logos.SplusObjects.AnalogOutput( ITEMS_SIZE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ITEMS_SIZE__AnalogSerialOutput__, ITEMS_SIZE );
    
    ITEM_ICON_IS = new InOutArray<AnalogOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        ITEM_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( ITEM_ICON_IS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( ITEM_ICON_IS__AnalogSerialOutput__ + i, ITEM_ICON_IS[i+1] );
    }
    
    DEFAULT_AVAILABLE_DEVICES = new Crestron.Logos.SplusObjects.StringInput( DEFAULT_AVAILABLE_DEVICES__AnalogSerialInput__, 99, this );
    m_StringInputList.Add( DEFAULT_AVAILABLE_DEVICES__AnalogSerialInput__, DEFAULT_AVAILABLE_DEVICES );
    
    DEVICE_NAME_IS = new InOutArray<StringInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DEVICE_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringInput( DEVICE_NAME_IS__AnalogSerialInput__ + i, DEVICE_NAME_IS__AnalogSerialInput__, 48, this );
        m_StringInputList.Add( DEVICE_NAME_IS__AnalogSerialInput__ + i, DEVICE_NAME_IS[i+1] );
    }
    
    DEVICE_DESCRIPTION_IS = new InOutArray<StringInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        DEVICE_DESCRIPTION_IS[i+1] = new Crestron.Logos.SplusObjects.StringInput( DEVICE_DESCRIPTION_IS__AnalogSerialInput__ + i, DEVICE_DESCRIPTION_IS__AnalogSerialInput__, 48, this );
        m_StringInputList.Add( DEVICE_DESCRIPTION_IS__AnalogSerialInput__ + i, DEVICE_DESCRIPTION_IS[i+1] );
    }
    
    DEVICE_SET = new Crestron.Logos.SplusObjects.StringOutput( DEVICE_SET__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DEVICE_SET__AnalogSerialOutput__, DEVICE_SET );
    
    ITEM_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        ITEM_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( ITEM_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( ITEM_NAME_IS__AnalogSerialOutput__ + i, ITEM_NAME_IS[i+1] );
    }
    
    ITEM_DESCRIPTION_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        ITEM_DESCRIPTION_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( ITEM_DESCRIPTION_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( ITEM_DESCRIPTION_IS__AnalogSerialOutput__ + i, ITEM_DESCRIPTION_IS[i+1] );
    }
    
    DEVICE_TYPE = new UShortParameter( DEVICE_TYPE__Parameter__, this );
    m_ParameterList.Add( DEVICE_TYPE__Parameter__, DEVICE_TYPE );
    
    DEVICES = new StringParameter( DEVICES__Parameter__, this );
    m_ParameterList.Add( DEVICES__Parameter__, DEVICES );
    
    
    for( uint i = 0; i < 48; i++ )
        ITEM_SELECT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( ITEM_SELECT_OnPush_0, false ) );
        
    DEVICE_DEFAULT_SELECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEVICE_DEFAULT_SELECT_OnPush_1, false ) );
    DEVICE_IS.OnAnalogChange.Add( new InputChangeHandlerWrapper( DEVICE_IS_OnChange_2, false ) );
    DEVICE_DEFAULT.OnAnalogChange.Add( new InputChangeHandlerWrapper( DEVICE_DEFAULT_OnChange_3, false ) );
    for( uint i = 0; i < 99; i++ )
        DEVICE_ICON_IS[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( DEVICE_ICON_IS_OnChange_4, false ) );
        
    for( uint i = 0; i < 99; i++ )
        DEVICE_DESCRIPTION_IS[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DEVICE_DESCRIPTION_IS_OnChange_5, false ) );
        
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_DEVICES_CONTROLLER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint DEVICE_DEFAULT_SELECT__DigitalInput__ = 1;
const uint ITEM_SELECT__DigitalInput__ = 2;
const uint ITEM_MATCHES__DigitalOutput__ = 0;
const uint DEVICE_IS__AnalogSerialInput__ = 0;
const uint DEVICE_DEFAULT__AnalogSerialInput__ = 1;
const uint DEFAULT_AVAILABLE_DEVICES__AnalogSerialInput__ = 2;
const uint DEVICE_ICON_IS__AnalogSerialInput__ = 3;
const uint DEVICE_NAME_IS__AnalogSerialInput__ = 102;
const uint DEVICE_DESCRIPTION_IS__AnalogSerialInput__ = 201;
const uint ITEMS_SIZE__AnalogSerialOutput__ = 0;
const uint DEVICE_SET__AnalogSerialOutput__ = 1;
const uint ITEM_ICON_IS__AnalogSerialOutput__ = 2;
const uint ITEM_NAME_IS__AnalogSerialOutput__ = 50;
const uint ITEM_DESCRIPTION_IS__AnalogSerialOutput__ = 98;
const uint DEVICE_TYPE__Parameter__ = 10;
const uint DEVICES__Parameter__ = 11;

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
