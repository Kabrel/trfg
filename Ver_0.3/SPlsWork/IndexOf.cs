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

namespace UserModule_INDEXOF
{
    public class UserModuleClass_INDEXOF : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.StringInput SEARCH__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput FOUND_FIRST;
        Crestron.Logos.SplusObjects.DigitalOutput FOUND_OTHER;
        Crestron.Logos.SplusObjects.AnalogOutput INDEX;
        Crestron.Logos.SplusObjects.StringOutput INDEX__DOLLAR__;
        UShortParameter SEARCH_TYPE;
        InOutArray<StringParameter> ELEMENTS;
        object SEARCH__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString __SEARCH_STRING__;
                __SEARCH_STRING__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
                
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 55;
                __SEARCH_STRING__  .UpdateValue ( SEARCH__DOLLAR__  ) ; 
                __context__.SourceCodeLine = 57;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (__SEARCH_STRING__ == ""))  ) ) 
                    { 
                    __context__.SourceCodeLine = 59;
                    Functions.TerminateEvent (); 
                    } 
                
                __context__.SourceCodeLine = 62;
                switch ((int)SEARCH_TYPE  .Value)
                
                    { 
                    case 10 : 
                    
                        { 
                        __context__.SourceCodeLine = 66;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)65; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 68;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ELEMENTS[ I ] == __SEARCH_STRING__))  ) ) 
                                { 
                                __context__.SourceCodeLine = 70;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 72;
                                    FOUND_FIRST  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 76;
                                    FOUND_OTHER  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 79;
                                INDEX  .Value = (ushort) ( (I - 1) ) ; 
                                __context__.SourceCodeLine = 80;
                                INDEX__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( INDEX  .Value ) )  ) ; 
                                __context__.SourceCodeLine = 81;
                                Functions.ProcessLogic ( ) ; 
                                __context__.SourceCodeLine = 83;
                                FOUND_FIRST  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 84;
                                FOUND_OTHER  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 85;
                                Functions.TerminateEvent (); 
                                } 
                            
                            __context__.SourceCodeLine = 66;
                            } 
                        
                        __context__.SourceCodeLine = 89;
                        break ; 
                        } 
                    
                    goto case 11 ;
                    case 11 : 
                    
                        { 
                        __context__.SourceCodeLine = 93;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)65; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 95;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( __SEARCH_STRING__ , ELEMENTS[ I ] ) > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 97;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 99;
                                    FOUND_FIRST  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 103;
                                    FOUND_OTHER  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 106;
                                INDEX  .Value = (ushort) ( (I - 1) ) ; 
                                __context__.SourceCodeLine = 107;
                                INDEX__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( INDEX  .Value ) )  ) ; 
                                __context__.SourceCodeLine = 108;
                                Functions.ProcessLogic ( ) ; 
                                __context__.SourceCodeLine = 110;
                                FOUND_FIRST  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 111;
                                FOUND_OTHER  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 112;
                                Functions.TerminateEvent (); 
                                } 
                            
                            __context__.SourceCodeLine = 93;
                            } 
                        
                        __context__.SourceCodeLine = 116;
                        break ; 
                        } 
                    
                    break;
                    } 
                    
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        FOUND_FIRST = new Crestron.Logos.SplusObjects.DigitalOutput( FOUND_FIRST__DigitalOutput__, this );
        m_DigitalOutputList.Add( FOUND_FIRST__DigitalOutput__, FOUND_FIRST );
        
        FOUND_OTHER = new Crestron.Logos.SplusObjects.DigitalOutput( FOUND_OTHER__DigitalOutput__, this );
        m_DigitalOutputList.Add( FOUND_OTHER__DigitalOutput__, FOUND_OTHER );
        
        INDEX = new Crestron.Logos.SplusObjects.AnalogOutput( INDEX__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( INDEX__AnalogSerialOutput__, INDEX );
        
        SEARCH__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SEARCH__DOLLAR____AnalogSerialInput__, 16, this );
        m_StringInputList.Add( SEARCH__DOLLAR____AnalogSerialInput__, SEARCH__DOLLAR__ );
        
        INDEX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( INDEX__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( INDEX__DOLLAR____AnalogSerialOutput__, INDEX__DOLLAR__ );
        
        SEARCH_TYPE = new UShortParameter( SEARCH_TYPE__Parameter__, this );
        m_ParameterList.Add( SEARCH_TYPE__Parameter__, SEARCH_TYPE );
        
        ELEMENTS = new InOutArray<StringParameter>( 65, this );
        for( uint i = 0; i < 65; i++ )
        {
            ELEMENTS[i+1] = new StringParameter( ELEMENTS__Parameter__ + i, ELEMENTS__Parameter__, this );
            m_ParameterList.Add( ELEMENTS__Parameter__ + i, ELEMENTS[i+1] );
        }
        
        
        SEARCH__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( SEARCH__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_INDEXOF ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint SEARCH__DOLLAR____AnalogSerialInput__ = 0;
    const uint FOUND_FIRST__DigitalOutput__ = 0;
    const uint FOUND_OTHER__DigitalOutput__ = 1;
    const uint INDEX__AnalogSerialOutput__ = 0;
    const uint INDEX__DOLLAR____AnalogSerialOutput__ = 1;
    const uint SEARCH_TYPE__Parameter__ = 10;
    const uint ELEMENTS__Parameter__ = 11;
    
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
