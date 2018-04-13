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
using Crestron.AppHelperClassesv2_0;

namespace CrestronModule_CRPCTAGAPPEND_V1_1_0
{
    public class CrestronModuleClass_CRPCTAGAPPEND_V1_1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput TAGGEDCRPCFROMCLIENT;
        Crestron.Logos.SplusObjects.BufferInput TAGGEDCRPCFROMSERVER;
        Crestron.Logos.SplusObjects.StringOutput TAGGEDCRPCTOSERVER;
        Crestron.Logos.SplusObjects.StringOutput TAGGEDCRPCTOCLIENT;
        ushort INITIALIZE = 0;
        CrestronString TAGIN;
        object TAGGEDCRPCFROMCLIENT_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString CLIENTCRPCDATA;
                CLIENTCRPCDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
                
                CrestronString TEMPSTRING;
                TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
                
                CrestronString TEMPLENGTH;
                TEMPLENGTH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
                
                uint COMMANDLENGTH = 0;
                
                CrestronString HEADER;
                HEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
                
                
                __context__.SourceCodeLine = 48;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 50;
                    HEADER  .UpdateValue ( Functions.Gather ( 8, TAGGEDCRPCFROMCLIENT )  ) ; 
                    __context__.SourceCodeLine = 52;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ) == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 54;
                        GenerateUserError ( "CRPC Version 1 Detected.  Please Upgrade Core 3 Controls.") ; 
                        __context__.SourceCodeLine = 55;
                        Functions.ClearBuffer ( TAGGEDCRPCFROMCLIENT ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 57;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ) == 2))  ) ) 
                            { 
                            __context__.SourceCodeLine = 60;
                            TEMPLENGTH  .UpdateValue ( Functions.Right ( HEADER ,  (int) ( 4 ) )  ) ; 
                            __context__.SourceCodeLine = 61;
                            COMMANDLENGTH = (uint) ( Functions.HextoL( TEMPLENGTH ) ) ; 
                            __context__.SourceCodeLine = 62;
                            TEMPSTRING  .UpdateValue ( Functions.Gather ( Functions.LowWord( (uint)( COMMANDLENGTH ) ), TAGGEDCRPCFROMCLIENT )  ) ; 
                            __context__.SourceCodeLine = 64;
                            TEMPSTRING  .UpdateValue ( HEADER + TEMPSTRING  ) ; 
                            __context__.SourceCodeLine = 66;
                            if ( Functions.TestForTrue  ( ( INITIALIZE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 69;
                                CLIENTCRPCDATA  .UpdateValue ( Functions.Right ( TEMPSTRING ,  (int) ( (Functions.Length( TEMPSTRING ) - 3) ) )  ) ; 
                                __context__.SourceCodeLine = 70;
                                MakeString ( TAGGEDCRPCTOSERVER , "{0:d}{1}{2}", (short)2, TAGIN , CLIENTCRPCDATA ) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 79;
                            GenerateUserError ( "Unable to process client CRPC message.  Version: {0:d}, Header:{1}", (short)Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ), HEADER ) ; 
                            __context__.SourceCodeLine = 80;
                            Functions.ClearBuffer ( TAGGEDCRPCFROMCLIENT ) ; 
                            } 
                        
                        }
                    
                    __context__.SourceCodeLine = 48;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object TAGGEDCRPCFROMSERVER_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString TAGREC;
            TAGREC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            CrestronString TAGWITHVER;
            TAGWITHVER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            CrestronString TEMPSTRING;
            TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
            
            CrestronString TEMPLENGTH;
            TEMPLENGTH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            CrestronString HEADER;
            HEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            uint COMMANDLENGTH = 0;
            
            
            __context__.SourceCodeLine = 94;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 96;
                HEADER  .UpdateValue ( Functions.Gather ( 8, TAGGEDCRPCFROMSERVER )  ) ; 
                __context__.SourceCodeLine = 98;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 100;
                    GenerateUserError ( "CRPC Version 1 Detected.  Please Upgrade Source Device Firmware.") ; 
                    __context__.SourceCodeLine = 101;
                    Functions.ClearBuffer ( TAGGEDCRPCFROMSERVER ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 103;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ) == 2))  ) ) 
                        { 
                        __context__.SourceCodeLine = 105;
                        TEMPLENGTH  .UpdateValue ( Functions.Right ( HEADER ,  (int) ( 4 ) )  ) ; 
                        __context__.SourceCodeLine = 106;
                        COMMANDLENGTH = (uint) ( Functions.HextoL( TEMPLENGTH ) ) ; 
                        __context__.SourceCodeLine = 107;
                        TEMPSTRING  .UpdateValue ( Functions.Gather ( Functions.LowWord( (uint)( COMMANDLENGTH ) ), TAGGEDCRPCFROMSERVER )  ) ; 
                        __context__.SourceCodeLine = 109;
                        TEMPSTRING  .UpdateValue ( HEADER + TEMPSTRING  ) ; 
                        __context__.SourceCodeLine = 113;
                        TAGWITHVER  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 115;
                        TAGREC  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( 3 ) )  ) ; 
                        __context__.SourceCodeLine = 118;
                        MakeString ( TAGWITHVER , "{0:d}{1}", (short)2, TAGIN ) ; 
                        __context__.SourceCodeLine = 122;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( INITIALIZE ) && Functions.TestForTrue ( Functions.BoolToInt (TAGREC == TAGWITHVER) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 124;
                            TAGGEDCRPCTOCLIENT  .UpdateValue ( TEMPSTRING  ) ; 
                            } 
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 131;
                        GenerateUserError ( "Unable to process source device CRPC message. Version: {0:d}, Header:{1}", (short)Functions.Atoi( Functions.Left( HEADER , (int)( 1 ) ) ), HEADER ) ; 
                        __context__.SourceCodeLine = 132;
                        Functions.ClearBuffer ( TAGGEDCRPCFROMSERVER ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 94;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    int GENERATEDTAG = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 147;
        GENERATEDTAG = (int) ( CRPCJoinTagGenerator.GetNewTag() ) ; 
        __context__.SourceCodeLine = 148;
        MakeString ( TAGIN , "{0:X2}", GENERATEDTAG) ; 
        __context__.SourceCodeLine = 149;
        INITIALIZE = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    TAGIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    
    TAGGEDCRPCTOSERVER = new Crestron.Logos.SplusObjects.StringOutput( TAGGEDCRPCTOSERVER__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TAGGEDCRPCTOSERVER__AnalogSerialOutput__, TAGGEDCRPCTOSERVER );
    
    TAGGEDCRPCTOCLIENT = new Crestron.Logos.SplusObjects.StringOutput( TAGGEDCRPCTOCLIENT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TAGGEDCRPCTOCLIENT__AnalogSerialOutput__, TAGGEDCRPCTOCLIENT );
    
    TAGGEDCRPCFROMCLIENT = new Crestron.Logos.SplusObjects.BufferInput( TAGGEDCRPCFROMCLIENT__AnalogSerialInput__, 65534, this );
    m_StringInputList.Add( TAGGEDCRPCFROMCLIENT__AnalogSerialInput__, TAGGEDCRPCFROMCLIENT );
    
    TAGGEDCRPCFROMSERVER = new Crestron.Logos.SplusObjects.BufferInput( TAGGEDCRPCFROMSERVER__AnalogSerialInput__, 65534, this );
    m_StringInputList.Add( TAGGEDCRPCFROMSERVER__AnalogSerialInput__, TAGGEDCRPCFROMSERVER );
    
    
    TAGGEDCRPCFROMCLIENT.OnSerialChange.Add( new InputChangeHandlerWrapper( TAGGEDCRPCFROMCLIENT_OnChange_0, true ) );
    TAGGEDCRPCFROMSERVER.OnSerialChange.Add( new InputChangeHandlerWrapper( TAGGEDCRPCFROMSERVER_OnChange_1, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_CRPCTAGAPPEND_V1_1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint TAGGEDCRPCFROMCLIENT__AnalogSerialInput__ = 0;
const uint TAGGEDCRPCFROMSERVER__AnalogSerialInput__ = 1;
const uint TAGGEDCRPCTOSERVER__AnalogSerialOutput__ = 0;
const uint TAGGEDCRPCTOCLIENT__AnalogSerialOutput__ = 1;

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
