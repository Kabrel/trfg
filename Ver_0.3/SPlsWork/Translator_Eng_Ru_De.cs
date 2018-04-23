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

namespace UserModule_TRANSLATOR_ENG_RU_DE
{
    public class UserModuleClass_TRANSLATOR_ENG_RU_DE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RULANG;
        Crestron.Logos.SplusObjects.DigitalInput DELANG;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SERIALIN;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SERIALOUT;
        InOutArray<StringParameter> CURRENTNAME;
        InOutArray<StringParameter> TRANSLATERU;
        InOutArray<StringParameter> TRANSLATEDE;
        object Event ( Object __EventInfo__ )
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort WORD = 0;
                
                ushort NAMING = 0;
                
                
                __context__.SourceCodeLine = 185;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RULANG  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 189;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)60; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( WORD  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (WORD  >= __FN_FORSTART_VAL__1) && (WORD  <= __FN_FOREND_VAL__1) ) : ( (WORD  <= __FN_FORSTART_VAL__1) && (WORD  >= __FN_FOREND_VAL__1) ) ; WORD  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 191;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)60; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( NAMING  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (NAMING  >= __FN_FORSTART_VAL__2) && (NAMING  <= __FN_FOREND_VAL__2) ) : ( (NAMING  <= __FN_FORSTART_VAL__2) && (NAMING  >= __FN_FOREND_VAL__2) ) ; NAMING  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 193;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SERIALIN[ WORD ] == CURRENTNAME[ NAMING ]))  ) ) 
                                { 
                                __context__.SourceCodeLine = 195;
                                SERIALOUT [ WORD]  .UpdateValue ( TRANSLATERU [ NAMING ]  ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 191;
                            } 
                        
                        __context__.SourceCodeLine = 189;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 200;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DELANG  .Value == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 202;
                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__3 = (ushort)60; 
                        int __FN_FORSTEP_VAL__3 = (int)1; 
                        for ( WORD  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (WORD  >= __FN_FORSTART_VAL__3) && (WORD  <= __FN_FOREND_VAL__3) ) : ( (WORD  <= __FN_FORSTART_VAL__3) && (WORD  >= __FN_FOREND_VAL__3) ) ; WORD  += (ushort)__FN_FORSTEP_VAL__3) 
                            { 
                            __context__.SourceCodeLine = 204;
                            ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__4 = (ushort)60; 
                            int __FN_FORSTEP_VAL__4 = (int)1; 
                            for ( NAMING  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (NAMING  >= __FN_FORSTART_VAL__4) && (NAMING  <= __FN_FOREND_VAL__4) ) : ( (NAMING  <= __FN_FORSTART_VAL__4) && (NAMING  >= __FN_FOREND_VAL__4) ) ; NAMING  += (ushort)__FN_FORSTEP_VAL__4) 
                                { 
                                __context__.SourceCodeLine = 206;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SERIALIN[ WORD ] == CURRENTNAME[ NAMING ]))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 208;
                                    SERIALOUT [ WORD]  .UpdateValue ( TRANSLATEDE [ NAMING ]  ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 204;
                                } 
                            
                            __context__.SourceCodeLine = 202;
                            } 
                        
                        } 
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        RULANG = new Crestron.Logos.SplusObjects.DigitalInput( RULANG__DigitalInput__, this );
        m_DigitalInputList.Add( RULANG__DigitalInput__, RULANG );
        
        DELANG = new Crestron.Logos.SplusObjects.DigitalInput( DELANG__DigitalInput__, this );
        m_DigitalInputList.Add( DELANG__DigitalInput__, DELANG );
        
        SERIALIN = new InOutArray<StringInput>( 60, this );
        for( uint i = 0; i < 60; i++ )
        {
            SERIALIN[i+1] = new Crestron.Logos.SplusObjects.StringInput( SERIALIN__AnalogSerialInput__ + i, SERIALIN__AnalogSerialInput__, 50, this );
            m_StringInputList.Add( SERIALIN__AnalogSerialInput__ + i, SERIALIN[i+1] );
        }
        
        SERIALOUT = new InOutArray<StringOutput>( 60, this );
        for( uint i = 0; i < 60; i++ )
        {
            SERIALOUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SERIALOUT__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( SERIALOUT__AnalogSerialOutput__ + i, SERIALOUT[i+1] );
        }
        
        CURRENTNAME = new InOutArray<StringParameter>( 60, this );
        for( uint i = 0; i < 60; i++ )
        {
            CURRENTNAME[i+1] = new StringParameter( CURRENTNAME__Parameter__ + i, CURRENTNAME__Parameter__, this );
            m_ParameterList.Add( CURRENTNAME__Parameter__ + i, CURRENTNAME[i+1] );
        }
        
        TRANSLATERU = new InOutArray<StringParameter>( 60, this );
        for( uint i = 0; i < 60; i++ )
        {
            TRANSLATERU[i+1] = new StringParameter( TRANSLATERU__Parameter__ + i, TRANSLATERU__Parameter__, this );
            m_ParameterList.Add( TRANSLATERU__Parameter__ + i, TRANSLATERU[i+1] );
        }
        
        TRANSLATEDE = new InOutArray<StringParameter>( 60, this );
        for( uint i = 0; i < 60; i++ )
        {
            TRANSLATEDE[i+1] = new StringParameter( TRANSLATEDE__Parameter__ + i, TRANSLATEDE__Parameter__, this );
            m_ParameterList.Add( TRANSLATEDE__Parameter__ + i, TRANSLATEDE[i+1] );
        }
        
        
        OnEventStatement.Add( new InputChangeHandlerWrapper( Event, false ) );
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_TRANSLATOR_ENG_RU_DE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RULANG__DigitalInput__ = 0;
    const uint DELANG__DigitalInput__ = 1;
    const uint SERIALIN__AnalogSerialInput__ = 0;
    const uint SERIALOUT__AnalogSerialOutput__ = 0;
    const uint CURRENTNAME__Parameter__ = 10;
    const uint TRANSLATERU__Parameter__ = 70;
    const uint TRANSLATEDE__Parameter__ = 130;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort CURLANG = 0;
            
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
