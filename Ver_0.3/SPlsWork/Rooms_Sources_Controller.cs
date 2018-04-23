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

namespace UserModule_ROOMS_SOURCES_CONTROLLER
{
    public class UserModuleClass_ROOMS_SOURCES_CONTROLLER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MOVE_ROOM;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> WATCH_SOURCE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> LISTEN_SOURCE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SHARE_SOURCE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SHARE_POWER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SHARE_VOLUME_UP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SHARE_VOLUME_DOWN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SHARE_VOLUME_MUTE_TOGGLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ROOM_VOLUME_MUTE_IS_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SOURCE_IN_USE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SOURCE_HAS_AUDIO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SOURCE_HAS_VIDEO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MOVE_ROOM_MATCHES;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> WATCH_SOURCE_MATCHES;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> WATCH_SOURCE_IN_USE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LISTEN_SOURCE_MATCHES;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LISTEN_SOURCE_IN_USE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SHARE_VISIBLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SHARE_SOURCE_MATCHES;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SHARE_POWER_IS_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SHARE_VOLUME_MUTE_IS_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ROOM_POWER_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ROOM_VOLUME_UP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ROOM_VOLUME_DOWN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ROOM_VOLUME_MUTE_TOGGLE;
        Crestron.Logos.SplusObjects.AnalogInput ROOM_IS;
        Crestron.Logos.SplusObjects.AnalogInput SOURCE_IS;
        Crestron.Logos.SplusObjects.StringInput DEFAULT_AVAILABLE_ROOMS;
        Crestron.Logos.SplusObjects.StringInput DEFAULT_AVAILABLE_SOURCES;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> ROOM_SOURCE_IS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> ROOM_VOLUME_IS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> SOURCE_ICON_IS;
        Crestron.Logos.SplusObjects.StringOutput ROOM_SET;
        Crestron.Logos.SplusObjects.StringOutput CONTROL_SOURCE_SET;
        Crestron.Logos.SplusObjects.AnalogOutput MOVES_SIZE;
        Crestron.Logos.SplusObjects.AnalogOutput WATCHES_SIZE;
        Crestron.Logos.SplusObjects.AnalogOutput LISTENS_SIZE;
        Crestron.Logos.SplusObjects.AnalogOutput SHARES_SIZE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MOVE_SOURCE_ICON_IS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> WATCH_SOURCE_ICON_IS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LISTEN_SOURCE_ICON_IS;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SHARE_SOURCE_ICON_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> ROOM_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> ROOM_SOURCES_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SOURCE_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MOVE_ROOM_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> MOVE_SOURCE_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> WATCH_SOURCE_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> WATCH_SOURCE_ROOM_NAMES_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LISTEN_SOURCE_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LISTEN_SOURCE_ROOM_NAMES_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SHARE_ROOM_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SHARE_SOURCE_NAME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SHARE_VOLUME_IS;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> ROOM_SOURCE;
        StringParameter ROOMS;
        StringParameter SHAREABLE_ROOMS;
        private ushort IDTOINDEX (  SplusExecutionContext __context__, ushort ID ) 
            { 
            ushort INDEX = 0;
            
            
            __context__.SourceCodeLine = 84;
            ID = (ushort) ( Functions.Low( (ushort) ID ) ) ; 
            __context__.SourceCodeLine = 85;
            INDEX = (ushort) ( Functions.Atoi( Functions.ItoHex( (int)( ID ) ) ) ) ; 
            __context__.SourceCodeLine = 87;
            return (ushort)( INDEX) ; 
            
            }
            
        private ushort INDEXTOID (  SplusExecutionContext __context__, ushort INDEX ) 
            { 
            ushort ID = 0;
            
            
            __context__.SourceCodeLine = 94;
            ID = (ushort) ( Functions.HextoI( Functions.ItoA( (int)( INDEX ) ) ) ) ; 
            __context__.SourceCodeLine = 96;
            return (ushort)( ID) ; 
            
            }
            
        CrestronString __ROOMS__;
        CrestronString __SHAREABLE_ROOMS__;
        CrestronString __SOURCES__;
        ushort [,] __ROOM_SOURCES__;
        ushort [] __MOVE_ROOM__;
        ushort [] __ROOM_MOVE__;
        ushort [] __WATCH_SOURCE__;
        ushort [] __SOURCE_WATCH__;
        ushort [] __LISTEN_SOURCE__;
        ushort [] __SOURCE_LISTEN__;
        ushort [] __SHARE_ROOM__;
        ushort [] __ROOM_SHARE__;
        private ushort MOVETOROOM (  SplusExecutionContext __context__, ushort MOVE ) 
            { 
            ushort ROOM = 0;
            
            
            __context__.SourceCodeLine = 114;
            ROOM = (ushort) ( __MOVE_ROOM__[ MOVE ] ) ; 
            __context__.SourceCodeLine = 116;
            return (ushort)( ROOM) ; 
            
            }
            
        private ushort ROOMTOMOVE (  SplusExecutionContext __context__, ushort ROOM ) 
            { 
            ushort MOVE = 0;
            
            
            __context__.SourceCodeLine = 123;
            MOVE = (ushort) ( __ROOM_MOVE__[ ROOM ] ) ; 
            __context__.SourceCodeLine = 125;
            return (ushort)( MOVE) ; 
            
            }
            
        private ushort WATCHTOSOURCE (  SplusExecutionContext __context__, ushort WATCH ) 
            { 
            ushort SOURCE = 0;
            
            
            __context__.SourceCodeLine = 132;
            SOURCE = (ushort) ( __WATCH_SOURCE__[ WATCH ] ) ; 
            __context__.SourceCodeLine = 134;
            return (ushort)( SOURCE) ; 
            
            }
            
        private ushort SOURCETOWATCH (  SplusExecutionContext __context__, ushort SOURCE ) 
            { 
            ushort WATCH = 0;
            
            
            __context__.SourceCodeLine = 141;
            WATCH = (ushort) ( __SOURCE_WATCH__[ SOURCE ] ) ; 
            __context__.SourceCodeLine = 143;
            return (ushort)( WATCH) ; 
            
            }
            
        private ushort LISTENTOSOURCE (  SplusExecutionContext __context__, ushort LISTEN ) 
            { 
            ushort SOURCE = 0;
            
            
            __context__.SourceCodeLine = 150;
            SOURCE = (ushort) ( __LISTEN_SOURCE__[ LISTEN ] ) ; 
            __context__.SourceCodeLine = 152;
            return (ushort)( SOURCE) ; 
            
            }
            
        private ushort SOURCETOLISTEN (  SplusExecutionContext __context__, ushort SOURCE ) 
            { 
            ushort LISTEN = 0;
            
            
            __context__.SourceCodeLine = 159;
            LISTEN = (ushort) ( __SOURCE_LISTEN__[ SOURCE ] ) ; 
            __context__.SourceCodeLine = 161;
            return (ushort)( LISTEN) ; 
            
            }
            
        private ushort SHARETOROOM (  SplusExecutionContext __context__, ushort SHARE ) 
            { 
            ushort ROOM = 0;
            
            
            __context__.SourceCodeLine = 168;
            ROOM = (ushort) ( __SHARE_ROOM__[ SHARE ] ) ; 
            __context__.SourceCodeLine = 170;
            return (ushort)( ROOM) ; 
            
            }
            
        private ushort ROOMTOSHARE (  SplusExecutionContext __context__, ushort ROOM ) 
            { 
            ushort SHARE = 0;
            
            
            __context__.SourceCodeLine = 177;
            SHARE = (ushort) ( __ROOM_SHARE__[ ROOM ] ) ; 
            __context__.SourceCodeLine = 179;
            return (ushort)( SHARE) ; 
            
            }
            
        object MOVE_ROOM_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort MOVE = 0;
                ushort ROOM = 0;
                
                
                __context__.SourceCodeLine = 189;
                MOVE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 190;
                ROOM = (ushort) ( MOVETOROOM( __context__ , (ushort)( MOVE ) ) ) ; 
                __context__.SourceCodeLine = 192;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 192;
                    Functions.TerminateEvent (); 
                    }
                
                __context__.SourceCodeLine = 194;
                MakeString ( ROOM_SET , "\u0010{0}", Functions.Chr ( INDEXTOID( __context__ , (ushort)( ROOM ) ) ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object WATCH_SOURCE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort WATCH = 0;
            ushort SOURCE = 0;
            
            
            __context__.SourceCodeLine = 201;
            WATCH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 202;
            SOURCE = (ushort) ( WATCHTOSOURCE( __context__ , (ushort)( WATCH ) ) ) ; 
            __context__.SourceCodeLine = 204;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SOURCE == 0))  ) ) 
                {
                __context__.SourceCodeLine = 204;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 206;
            MakeString ( ROOM_SOURCE [ IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) )] , "\u0050{0}", Functions.Chr ( INDEXTOID( __context__ , (ushort)( SOURCE ) ) ) ) ; 
            __context__.SourceCodeLine = 207;
            MakeString ( CONTROL_SOURCE_SET , "\u0050{0}", Functions.Chr ( INDEXTOID( __context__ , (ushort)( SOURCE ) ) ) ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object LISTEN_SOURCE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort LISTEN = 0;
        ushort SOURCE = 0;
        
        
        __context__.SourceCodeLine = 214;
        LISTEN = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 215;
        SOURCE = (ushort) ( LISTENTOSOURCE( __context__ , (ushort)( LISTEN ) ) ) ; 
        __context__.SourceCodeLine = 217;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SOURCE == 0))  ) ) 
            {
            __context__.SourceCodeLine = 217;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 219;
        MakeString ( ROOM_SOURCE [ IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) )] , "\u0050{0}", Functions.Chr ( INDEXTOID( __context__ , (ushort)( SOURCE ) ) ) ) ; 
        __context__.SourceCodeLine = 220;
        MakeString ( CONTROL_SOURCE_SET , "\u0050{0}", Functions.Chr ( INDEXTOID( __context__ , (ushort)( SOURCE ) ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHARE_SOURCE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort SHARE = 0;
        ushort ROOM = 0;
        
        CrestronString __SOURCES__;
        __SOURCES__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 99, this );
        
        
        __context__.SourceCodeLine = 228;
        SHARE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 229;
        ROOM = (ushort) ( SHARETOROOM( __context__ , (ushort)( SHARE ) ) ) ; 
        __context__.SourceCodeLine = 231;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
            {
            __context__.SourceCodeLine = 231;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 233;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM_SOURCES_IS[ ROOM ] == ""))  ) ) 
            { 
            __context__.SourceCodeLine = 235;
            __SOURCES__  .UpdateValue ( DEFAULT_AVAILABLE_SOURCES  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 237;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM_SOURCES_IS[ ROOM ] == "\u0000"))  ) ) 
                { 
                __context__.SourceCodeLine = 239;
                __SOURCES__  .UpdateValue ( ""  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 243;
                __SOURCES__  .UpdateValue ( ROOM_SOURCES_IS [ ROOM ]  ) ; 
                } 
            
            }
        
        __context__.SourceCodeLine = 246;
        if ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( SOURCE_IS  .UshortValue ) ) , __SOURCES__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 248;
            MakeString ( ROOM_SOURCE [ ROOM] , "\u0050{0}", Functions.Chr ( SOURCE_IS  .UshortValue ) ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 250;
            if ( Functions.TestForTrue  ( ( Functions.Find( Functions.Chr( (int)( (64 + SOURCE_IS  .UshortValue) ) ) , __SOURCES__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 252;
                MakeString ( ROOM_SOURCE [ ROOM] , "\u0050{0}", Functions.Chr ( (64 + SOURCE_IS  .UshortValue) ) ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHARE_POWER_OFF_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort SHARE = 0;
        ushort ROOM = 0;
        
        
        __context__.SourceCodeLine = 260;
        SHARE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 261;
        ROOM = (ushort) ( SHARETOROOM( __context__ , (ushort)( SHARE ) ) ) ; 
        __context__.SourceCodeLine = 263;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
            {
            __context__.SourceCodeLine = 263;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 265;
        ROOM_POWER_OFF [ ROOM]  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 266;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 267;
        ROOM_POWER_OFF [ ROOM]  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHARE_VOLUME_UP_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort SHARE = 0;
        ushort ROOM = 0;
        ushort STATE = 0;
        
        
        __context__.SourceCodeLine = 274;
        SHARE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 275;
        ROOM = (ushort) ( SHARETOROOM( __context__ , (ushort)( SHARE ) ) ) ; 
        __context__.SourceCodeLine = 277;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
            {
            __context__.SourceCodeLine = 277;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 279;
        STATE = (ushort) ( SHARE_VOLUME_UP[ SHARE ] .Value ) ; 
        __context__.SourceCodeLine = 280;
        ROOM_VOLUME_UP [ ROOM]  .Value = (ushort) ( STATE ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHARE_VOLUME_DOWN_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort SHARE = 0;
        ushort ROOM = 0;
        ushort STATE = 0;
        
        
        __context__.SourceCodeLine = 287;
        SHARE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 288;
        ROOM = (ushort) ( SHARETOROOM( __context__ , (ushort)( SHARE ) ) ) ; 
        __context__.SourceCodeLine = 290;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
            {
            __context__.SourceCodeLine = 290;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 292;
        STATE = (ushort) ( SHARE_VOLUME_DOWN[ SHARE ] .Value ) ; 
        __context__.SourceCodeLine = 293;
        ROOM_VOLUME_DOWN [ ROOM]  .Value = (ushort) ( STATE ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHARE_VOLUME_MUTE_TOGGLE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort SHARE = 0;
        ushort ROOM = 0;
        ushort STATE = 0;
        
        
        __context__.SourceCodeLine = 300;
        SHARE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 301;
        ROOM = (ushort) ( SHARETOROOM( __context__ , (ushort)( SHARE ) ) ) ; 
        __context__.SourceCodeLine = 303;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
            {
            __context__.SourceCodeLine = 303;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 305;
        ROOM_VOLUME_MUTE_TOGGLE [ ROOM]  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 306;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 307;
        ROOM_VOLUME_MUTE_TOGGLE [ ROOM]  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void UPDATEMOVEROOM (  SplusExecutionContext __context__ ) 
    { 
    ushort MOVE = 0;
    
    
    __context__.SourceCodeLine = 317;
    Functions.SetArray ( MOVE_ROOM_MATCHES , (ushort)0) ; 
    __context__.SourceCodeLine = 319;
    MOVE = (ushort) ( ROOMTOMOVE( __context__ , (ushort)( IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) ) ) ) ) ; 
    __context__.SourceCodeLine = 320;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MOVE == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 322;
        return ; 
        } 
    
    __context__.SourceCodeLine = 325;
    MOVE_ROOM_MATCHES [ MOVE]  .Value = (ushort) ( 1 ) ; 
    
    }
    
private void UPDATEMOVESOURCE (  SplusExecutionContext __context__, ushort ROOM ) 
    { 
    ushort MOVE = 0;
    ushort SOURCE = 0;
    
    
    __context__.SourceCodeLine = 332;
    MOVE = (ushort) ( ROOMTOMOVE( __context__ , (ushort)( ROOM ) ) ) ; 
    __context__.SourceCodeLine = 333;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MOVE == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 335;
        return ; 
        } 
    
    __context__.SourceCodeLine = 338;
    SOURCE = (ushort) ( IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) ) ; 
    __context__.SourceCodeLine = 339;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SOURCE > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 341;
        MOVE_SOURCE_NAME_IS [ MOVE]  .UpdateValue ( SOURCE_NAME_IS [ SOURCE ]  ) ; 
        __context__.SourceCodeLine = 342;
        MOVE_SOURCE_ICON_IS [ MOVE]  .Value = (ushort) ( SOURCE_ICON_IS[ SOURCE ] .UshortValue ) ; 
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 346;
        MOVE_SOURCE_NAME_IS [ MOVE]  .UpdateValue ( "Off"  ) ; 
        __context__.SourceCodeLine = 347;
        MOVE_SOURCE_ICON_IS [ MOVE]  .Value = (ushort) ( 0 ) ; 
        } 
    
    
    }
    
private void UPDATEMOVE (  SplusExecutionContext __context__ ) 
    { 
    ushort I = 0;
    ushort ITEM = 0;
    ushort ROOM = 0;
    
    
    __context__.SourceCodeLine = 355;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (__ROOMS__ == ""))  ) ) 
        { 
        __context__.SourceCodeLine = 357;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOMS  != ""))  ) ) 
            { 
            __context__.SourceCodeLine = 359;
            __ROOMS__  .UpdateValue ( ROOMS  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 361;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEFAULT_AVAILABLE_ROOMS != ""))  ) ) 
                { 
                __context__.SourceCodeLine = 363;
                __ROOMS__  .UpdateValue ( DEFAULT_AVAILABLE_ROOMS  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 367;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)99; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 369;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM_NAME_IS[ I ] != ""))  ) ) 
                        { 
                        __context__.SourceCodeLine = 371;
                        MakeString ( __ROOMS__ , "{0}{1}", __ROOMS__ , Functions.Chr ( INDEXTOID( __context__ , (ushort)( I ) ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 367;
                    } 
                
                } 
            
            }
        
        } 
    
    __context__.SourceCodeLine = 377;
    MOVES_SIZE  .Value = (ushort) ( Functions.Length( __ROOMS__ ) ) ; 
    __context__.SourceCodeLine = 379;
    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__2 = (ushort)MOVES_SIZE  .Value; 
    int __FN_FORSTEP_VAL__2 = (int)1; 
    for ( ITEM  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (ITEM  >= __FN_FORSTART_VAL__2) && (ITEM  <= __FN_FOREND_VAL__2) ) : ( (ITEM  <= __FN_FORSTART_VAL__2) && (ITEM  >= __FN_FOREND_VAL__2) ) ; ITEM  += (ushort)__FN_FORSTEP_VAL__2) 
        { 
        __context__.SourceCodeLine = 381;
        ROOM = (ushort) ( Byte( __ROOMS__ , (int)( ITEM ) ) ) ; 
        __context__.SourceCodeLine = 382;
        ROOM = (ushort) ( IDTOINDEX( __context__ , (ushort)( ROOM ) ) ) ; 
        __context__.SourceCodeLine = 384;
        __MOVE_ROOM__ [ ITEM] = (ushort) ( ROOM ) ; 
        __context__.SourceCodeLine = 385;
        __ROOM_MOVE__ [ ROOM] = (ushort) ( ITEM ) ; 
        __context__.SourceCodeLine = 387;
        MOVE_ROOM_NAME_IS [ ITEM]  .UpdateValue ( ROOM_NAME_IS [ ROOM ]  ) ; 
        __context__.SourceCodeLine = 389;
        UPDATEMOVESOURCE (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 379;
        } 
    
    __context__.SourceCodeLine = 392;
    UPDATEMOVEROOM (  __context__  ) ; 
    
    }
    
private void UPDATEWATCH (  SplusExecutionContext __context__, ushort SOURCE ) 
    { 
    ushort ITEM = 0;
    ushort MATCHES = 0;
    ushort ROOM = 0;
    ushort ROOMS_COUNT = 0;
    ushort OTHER_SOURCE = 0;
    ushort OTHER_ITEM = 0;
    
    CrestronString ROOM_NAMES;
    ROOM_NAMES  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    
    __context__.SourceCodeLine = 403;
    ITEM = (ushort) ( SOURCETOWATCH( __context__ , (ushort)( SOURCE ) ) ) ; 
    __context__.SourceCodeLine = 404;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEM == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 406;
        return ; 
        } 
    
    __context__.SourceCodeLine = 409;
    WATCH_SOURCE_NAME_IS [ ITEM]  .UpdateValue ( SOURCE_NAME_IS [ SOURCE ]  ) ; 
    __context__.SourceCodeLine = 410;
    WATCH_SOURCE_ICON_IS [ ITEM]  .Value = (ushort) ( SOURCE_ICON_IS[ SOURCE ] .UshortValue ) ; 
    __context__.SourceCodeLine = 412;
    MATCHES = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 413;
    ROOM = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 414;
    ROOMS_COUNT = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 417;
    OTHER_SOURCE = (ushort) ( (INDEXTOID( __context__ , (ushort)( SOURCE ) ) + 64) ) ; 
    __context__.SourceCodeLine = 418;
    OTHER_SOURCE = (ushort) ( IDTOINDEX( __context__ , (ushort)( OTHER_SOURCE ) ) ) ; 
    __context__.SourceCodeLine = 419;
    OTHER_ITEM = (ushort) ( SOURCETOLISTEN( __context__ , (ushort)( OTHER_SOURCE ) ) ) ; 
    __context__.SourceCodeLine = 421;
    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ROOM <= 99 ))  ) ) 
        { 
        __context__.SourceCodeLine = 423;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) == SOURCE))  ) ) 
            { 
            __context__.SourceCodeLine = 425;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) ) == ROOM))  ) ) 
                { 
                __context__.SourceCodeLine = 427;
                MATCHES = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 430;
            ROOMS_COUNT = (ushort) ( (ROOMS_COUNT + 1) ) ; 
            __context__.SourceCodeLine = 431;
            switch ((int)ROOMS_COUNT)
            
                { 
                case 1 : 
                
                    { 
                    __context__.SourceCodeLine = 435;
                    ROOM_NAMES  .UpdateValue ( ROOM_NAME_IS [ ROOM ]  ) ; 
                    __context__.SourceCodeLine = 437;
                    break ; 
                    } 
                
                goto case 2 ;
                case 2 : 
                
                    { 
                    __context__.SourceCodeLine = 441;
                    ROOM_NAMES  .UpdateValue ( ROOM_NAMES + ", " + ROOM_NAME_IS [ ROOM ]  ) ; 
                    __context__.SourceCodeLine = 443;
                    break ; 
                    } 
                
                break;
                } 
                
            
            } 
        
        __context__.SourceCodeLine = 448;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 450;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) == OTHER_SOURCE))  ) ) 
                { 
                __context__.SourceCodeLine = 452;
                switch ((int)ROOMS_COUNT)
                
                    { 
                    case 1 : 
                    
                        { 
                        __context__.SourceCodeLine = 456;
                        ROOM_NAMES  .UpdateValue ( ROOM_NAME_IS [ ROOM ]  ) ; 
                        __context__.SourceCodeLine = 458;
                        break ; 
                        } 
                    
                    goto case 2 ;
                    case 2 : 
                    
                        { 
                        __context__.SourceCodeLine = 462;
                        ROOM_NAMES  .UpdateValue ( ROOM_NAMES + ", " + ROOM_NAME_IS [ ROOM ]  ) ; 
                        __context__.SourceCodeLine = 464;
                        break ; 
                        } 
                    
                    break;
                    } 
                    
                
                } 
            
            } 
        
        __context__.SourceCodeLine = 470;
        ROOM = (ushort) ( (ROOM + 1) ) ; 
        __context__.SourceCodeLine = 421;
        } 
    
    __context__.SourceCodeLine = 473;
    WATCH_SOURCE_MATCHES [ ITEM]  .Value = (ushort) ( MATCHES ) ; 
    __context__.SourceCodeLine = 475;
    switch ((int)ROOMS_COUNT)
    
        { 
        case 0 : 
        
            { 
            __context__.SourceCodeLine = 479;
            WATCH_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 480;
            WATCH_SOURCE_ROOM_NAMES_IS [ ITEM]  .UpdateValue ( "Not In Use"  ) ; 
            __context__.SourceCodeLine = 482;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 484;
                LISTEN_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 485;
                LISTEN_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM]  .UpdateValue ( "Not In Use"  ) ; 
                } 
            
            __context__.SourceCodeLine = 488;
            break ; 
            } 
        
        goto case 1 ;
        case 1 : 
        
            { 
            __context__.SourceCodeLine = 492;
            WATCH_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 493;
            WATCH_SOURCE_ROOM_NAMES_IS [ ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
            __context__.SourceCodeLine = 495;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 497;
                LISTEN_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 498;
                LISTEN_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
                } 
            
            __context__.SourceCodeLine = 501;
            break ; 
            } 
        
        goto case 2 ;
        case 2 : 
        
            { 
            __context__.SourceCodeLine = 505;
            WATCH_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 506;
            WATCH_SOURCE_ROOM_NAMES_IS [ ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
            __context__.SourceCodeLine = 508;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 510;
                LISTEN_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 511;
                LISTEN_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
                } 
            
            __context__.SourceCodeLine = 514;
            break ; 
            } 
        
        goto default;
        default : 
        
            { 
            __context__.SourceCodeLine = 518;
            WATCH_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 519;
            MakeString ( WATCH_SOURCE_ROOM_NAMES_IS [ ITEM] , "{0}, and {1:d} more", ROOM_NAMES , (ushort)(ROOMS_COUNT - 2)) ; 
            __context__.SourceCodeLine = 521;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 523;
                LISTEN_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 524;
                MakeString ( LISTEN_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM] , "{0}, and {1:d} more", ROOM_NAMES , (ushort)(ROOMS_COUNT - 2)) ; 
                } 
            
            } 
        break;
        
        } 
        
    
    
    }
    
private void UPDATELISTEN (  SplusExecutionContext __context__, ushort SOURCE ) 
    { 
    ushort ITEM = 0;
    ushort MATCHES = 0;
    ushort ROOM = 0;
    ushort ROOMS_COUNT = 0;
    ushort OTHER_SOURCE = 0;
    ushort OTHER_ITEM = 0;
    
    CrestronString ROOM_NAMES;
    ROOM_NAMES  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    
    __context__.SourceCodeLine = 535;
    ITEM = (ushort) ( SOURCETOLISTEN( __context__ , (ushort)( SOURCE ) ) ) ; 
    __context__.SourceCodeLine = 536;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ITEM == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 538;
        return ; 
        } 
    
    __context__.SourceCodeLine = 541;
    LISTEN_SOURCE_NAME_IS [ ITEM]  .UpdateValue ( SOURCE_NAME_IS [ SOURCE ]  ) ; 
    __context__.SourceCodeLine = 542;
    LISTEN_SOURCE_ICON_IS [ ITEM]  .Value = (ushort) ( SOURCE_ICON_IS[ SOURCE ] .UshortValue ) ; 
    __context__.SourceCodeLine = 544;
    MATCHES = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 545;
    ROOM = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 546;
    ROOMS_COUNT = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 549;
    OTHER_SOURCE = (ushort) ( (INDEXTOID( __context__ , (ushort)( SOURCE ) ) - 64) ) ; 
    __context__.SourceCodeLine = 550;
    OTHER_SOURCE = (ushort) ( IDTOINDEX( __context__ , (ushort)( OTHER_SOURCE ) ) ) ; 
    __context__.SourceCodeLine = 551;
    OTHER_ITEM = (ushort) ( SOURCETOWATCH( __context__ , (ushort)( OTHER_SOURCE ) ) ) ; 
    __context__.SourceCodeLine = 553;
    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ROOM <= 99 ))  ) ) 
        { 
        __context__.SourceCodeLine = 555;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) == SOURCE))  ) ) 
            { 
            __context__.SourceCodeLine = 557;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) ) == ROOM))  ) ) 
                { 
                __context__.SourceCodeLine = 559;
                MATCHES = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 562;
            ROOMS_COUNT = (ushort) ( (ROOMS_COUNT + 1) ) ; 
            __context__.SourceCodeLine = 563;
            switch ((int)ROOMS_COUNT)
            
                { 
                case 1 : 
                
                    { 
                    __context__.SourceCodeLine = 567;
                    ROOM_NAMES  .UpdateValue ( ROOM_NAME_IS [ ROOM ]  ) ; 
                    __context__.SourceCodeLine = 569;
                    break ; 
                    } 
                
                goto case 2 ;
                case 2 : 
                
                    { 
                    __context__.SourceCodeLine = 573;
                    ROOM_NAMES  .UpdateValue ( ROOM_NAMES + ", " + ROOM_NAME_IS [ ROOM ]  ) ; 
                    __context__.SourceCodeLine = 575;
                    break ; 
                    } 
                
                break;
                } 
                
            
            } 
        
        __context__.SourceCodeLine = 580;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 582;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) == OTHER_SOURCE))  ) ) 
                { 
                __context__.SourceCodeLine = 584;
                switch ((int)ROOMS_COUNT)
                
                    { 
                    case 1 : 
                    
                        { 
                        __context__.SourceCodeLine = 588;
                        ROOM_NAMES  .UpdateValue ( ROOM_NAME_IS [ ROOM ]  ) ; 
                        __context__.SourceCodeLine = 590;
                        break ; 
                        } 
                    
                    goto case 2 ;
                    case 2 : 
                    
                        { 
                        __context__.SourceCodeLine = 594;
                        ROOM_NAMES  .UpdateValue ( ROOM_NAMES + ", " + ROOM_NAME_IS [ ROOM ]  ) ; 
                        __context__.SourceCodeLine = 596;
                        break ; 
                        } 
                    
                    break;
                    } 
                    
                
                } 
            
            } 
        
        __context__.SourceCodeLine = 602;
        ROOM = (ushort) ( (ROOM + 1) ) ; 
        __context__.SourceCodeLine = 553;
        } 
    
    __context__.SourceCodeLine = 605;
    LISTEN_SOURCE_MATCHES [ ITEM]  .Value = (ushort) ( MATCHES ) ; 
    __context__.SourceCodeLine = 607;
    switch ((int)ROOMS_COUNT)
    
        { 
        case 0 : 
        
            { 
            __context__.SourceCodeLine = 611;
            LISTEN_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 612;
            LISTEN_SOURCE_ROOM_NAMES_IS [ ITEM]  .UpdateValue ( "Not In Use"  ) ; 
            __context__.SourceCodeLine = 614;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 616;
                WATCH_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 617;
                WATCH_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM]  .UpdateValue ( "Not In Use"  ) ; 
                } 
            
            __context__.SourceCodeLine = 620;
            break ; 
            } 
        
        goto case 1 ;
        case 1 : 
        
            { 
            __context__.SourceCodeLine = 624;
            LISTEN_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 625;
            LISTEN_SOURCE_ROOM_NAMES_IS [ ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
            __context__.SourceCodeLine = 627;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 629;
                WATCH_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 630;
                WATCH_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
                } 
            
            __context__.SourceCodeLine = 633;
            break ; 
            } 
        
        goto case 2 ;
        case 2 : 
        
            { 
            __context__.SourceCodeLine = 637;
            LISTEN_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 638;
            LISTEN_SOURCE_ROOM_NAMES_IS [ ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
            __context__.SourceCodeLine = 640;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 642;
                WATCH_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 643;
                WATCH_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM]  .UpdateValue ( ROOM_NAMES  ) ; 
                } 
            
            __context__.SourceCodeLine = 646;
            break ; 
            } 
        
        goto default;
        default : 
        
            { 
            __context__.SourceCodeLine = 650;
            LISTEN_SOURCE_IN_USE [ ITEM]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 651;
            MakeString ( LISTEN_SOURCE_ROOM_NAMES_IS [ ITEM] , "{0}, and {1:d} more", ROOM_NAMES , (ushort)(ROOMS_COUNT - 2)) ; 
            __context__.SourceCodeLine = 653;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( OTHER_ITEM > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 655;
                WATCH_SOURCE_IN_USE [ OTHER_ITEM]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 656;
                MakeString ( WATCH_SOURCE_ROOM_NAMES_IS [ OTHER_ITEM] , "{0}, and {1:d} more", ROOM_NAMES , (ushort)(ROOMS_COUNT - 2)) ; 
                } 
            
            } 
        break;
        
        } 
        
    
    
    }
    
private void UPDATEWATCHLISTEN (  SplusExecutionContext __context__ ) 
    { 
    ushort I = 0;
    ushort ROOM = 0;
    ushort SOURCE = 0;
    
    
    __context__.SourceCodeLine = 666;
    ROOM = (ushort) ( IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) ) ) ; 
    __context__.SourceCodeLine = 668;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 670;
        return ; 
        } 
    
    __context__.SourceCodeLine = 673;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM_SOURCES_IS[ ROOM ] != ""))  ) ) 
        { 
        __context__.SourceCodeLine = 675;
        __SOURCES__  .UpdateValue ( ROOM_SOURCES_IS [ ROOM ]  ) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 677;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEFAULT_AVAILABLE_SOURCES != ""))  ) ) 
            { 
            __context__.SourceCodeLine = 679;
            __SOURCES__  .UpdateValue ( DEFAULT_AVAILABLE_SOURCES  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 683;
            __SOURCES__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 685;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)99; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 687;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SOURCE_NAME_IS[ I ] != ""))  ) ) 
                    { 
                    __context__.SourceCodeLine = 689;
                    MakeString ( __SOURCES__ , "{0}{1}", __SOURCES__ , Functions.Chr ( INDEXTOID( __context__ , (ushort)( I ) ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 685;
                } 
            
            } 
        
        }
    
    __context__.SourceCodeLine = 694;
    WATCHES_SIZE  .Value = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 695;
    LISTENS_SIZE  .Value = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 697;
    Functions.SetArray (  ref __WATCH_SOURCE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 698;
    Functions.SetArray (  ref __SOURCE_WATCH__ , (ushort)0) ; 
    __context__.SourceCodeLine = 699;
    Functions.SetArray (  ref __LISTEN_SOURCE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 700;
    Functions.SetArray (  ref __SOURCE_LISTEN__ , (ushort)0) ; 
    __context__.SourceCodeLine = 702;
    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__2 = (ushort)Functions.Length( __SOURCES__ ); 
    int __FN_FORSTEP_VAL__2 = (int)1; 
    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
        { 
        __context__.SourceCodeLine = 704;
        SOURCE = (ushort) ( Byte( __SOURCES__ , (int)( I ) ) ) ; 
        __context__.SourceCodeLine = 705;
        SOURCE = (ushort) ( IDTOINDEX( __context__ , (ushort)( SOURCE ) ) ) ; 
        __context__.SourceCodeLine = 707;
        /* Trace( "UpdateWatchListen() source: {0:d}", (ushort)SOURCE) */ ; 
        __context__.SourceCodeLine = 709;
        if ( Functions.TestForTrue  ( ( SOURCE_HAS_VIDEO[ SOURCE ] .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 711;
            WATCHES_SIZE  .Value = (ushort) ( (WATCHES_SIZE  .Value + 1) ) ; 
            __context__.SourceCodeLine = 712;
            __WATCH_SOURCE__ [ WATCHES_SIZE  .Value] = (ushort) ( SOURCE ) ; 
            __context__.SourceCodeLine = 713;
            __SOURCE_WATCH__ [ SOURCE] = (ushort) ( WATCHES_SIZE  .Value ) ; 
            __context__.SourceCodeLine = 715;
            UPDATEWATCH (  __context__ , (ushort)( SOURCE )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 719;
            LISTENS_SIZE  .Value = (ushort) ( (LISTENS_SIZE  .Value + 1) ) ; 
            __context__.SourceCodeLine = 720;
            __LISTEN_SOURCE__ [ LISTENS_SIZE  .Value] = (ushort) ( SOURCE ) ; 
            __context__.SourceCodeLine = 721;
            __SOURCE_LISTEN__ [ SOURCE] = (ushort) ( LISTENS_SIZE  .Value ) ; 
            __context__.SourceCodeLine = 723;
            UPDATELISTEN (  __context__ , (ushort)( SOURCE )) ; 
            } 
        
        __context__.SourceCodeLine = 702;
        } 
    
    
    }
    
private void UPDATESHARESOURCE (  SplusExecutionContext __context__, ushort ROOM ) 
    { 
    ushort SHARE = 0;
    ushort SOURCE = 0;
    
    
    __context__.SourceCodeLine = 735;
    SHARE = (ushort) ( ROOMTOSHARE( __context__ , (ushort)( ROOM ) ) ) ; 
    __context__.SourceCodeLine = 736;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHARE == 0))  ) ) 
        {
        __context__.SourceCodeLine = 736;
        return ; 
        }
    
    __context__.SourceCodeLine = 738;
    SOURCE = (ushort) ( IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) ) ; 
    __context__.SourceCodeLine = 739;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SOURCE > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 741;
        SHARE_SOURCE_NAME_IS [ SHARE]  .UpdateValue ( SOURCE_NAME_IS [ SOURCE ]  ) ; 
        __context__.SourceCodeLine = 742;
        SHARE_SOURCE_ICON_IS [ SHARE]  .Value = (ushort) ( SOURCE_ICON_IS[ SOURCE ] .UshortValue ) ; 
        __context__.SourceCodeLine = 743;
        SHARE_POWER_IS_ON [ SHARE]  .Value = (ushort) ( 1 ) ; 
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 747;
        SHARE_SOURCE_NAME_IS [ SHARE]  .UpdateValue ( "Off"  ) ; 
        __context__.SourceCodeLine = 748;
        SHARE_SOURCE_ICON_IS [ SHARE]  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 749;
        SHARE_POWER_IS_ON [ SHARE]  .Value = (ushort) ( 0 ) ; 
        } 
    
    
    }
    
private void UPDATESHAREVISIBLE (  SplusExecutionContext __context__, ushort ROOM ) 
    { 
    ushort SHARE = 0;
    ushort SOURCE = 0;
    
    CrestronString __SOURCES__;
    __SOURCES__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 99, this );
    
    
    __context__.SourceCodeLine = 758;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM_SOURCES_IS[ ROOM ] == ""))  ) ) 
        { 
        __context__.SourceCodeLine = 760;
        __SOURCES__  .UpdateValue ( DEFAULT_AVAILABLE_SOURCES  ) ; 
        } 
    
    else 
        {
        __context__.SourceCodeLine = 762;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM_SOURCES_IS[ ROOM ] == "\u0000"))  ) ) 
            { 
            __context__.SourceCodeLine = 764;
            __SOURCES__  .UpdateValue ( ""  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 768;
            __SOURCES__  .UpdateValue ( ROOM_SOURCES_IS [ ROOM ]  ) ; 
            } 
        
        }
    
    __context__.SourceCodeLine = 771;
    SHARE = (ushort) ( ROOMTOSHARE( __context__ , (ushort)( ROOM ) ) ) ; 
    __context__.SourceCodeLine = 772;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHARE == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 774;
        return ; 
        } 
    
    __context__.SourceCodeLine = 777;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOM == IDTOINDEX( __context__ , (ushort)( ROOM_IS  .UshortValue ) )))  ) ) 
        { 
        __context__.SourceCodeLine = 779;
        SHARE_VISIBLE [ SHARE]  .Value = (ushort) ( 0 ) ; 
        } 
    
    else 
        { 
        __context__.SourceCodeLine = 783;
        SHARE_VISIBLE [ SHARE]  .Value = (ushort) ( Functions.Find( Functions.Chr( (int)( SOURCE_IS  .UshortValue ) ) , __SOURCES__ ) ) ; 
        __context__.SourceCodeLine = 785;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHARE_VISIBLE[ SHARE ] .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 787;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SOURCE_IS  .UshortValue < 64 ))  ) ) 
                { 
                __context__.SourceCodeLine = 789;
                SHARE_VISIBLE [ SHARE]  .Value = (ushort) ( Functions.Find( Functions.Chr( (int)( (64 + SOURCE_IS  .UshortValue) ) ) , __SOURCES__ ) ) ; 
                } 
            
            } 
        
        } 
    
    
    }
    
private void UPDATESHAREVOLUME (  SplusExecutionContext __context__, ushort ROOM ) 
    { 
    ushort SHARE = 0;
    
    
    __context__.SourceCodeLine = 799;
    SHARE = (ushort) ( ROOMTOSHARE( __context__ , (ushort)( ROOM ) ) ) ; 
    __context__.SourceCodeLine = 800;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHARE == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 802;
        return ; 
        } 
    
    __context__.SourceCodeLine = 805;
    MakeString ( SHARE_VOLUME_IS [ SHARE] , "{0:d}", (ushort)(ROOM_VOLUME_IS[ ROOM ] .UshortValue / 655)) ; 
    
    }
    
private void UPDATESHAREVOLUMEMUTE (  SplusExecutionContext __context__, ushort ROOM ) 
    { 
    ushort SHARE = 0;
    
    
    __context__.SourceCodeLine = 812;
    SHARE = (ushort) ( ROOMTOSHARE( __context__ , (ushort)( ROOM ) ) ) ; 
    __context__.SourceCodeLine = 813;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHARE == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 815;
        return ; 
        } 
    
    __context__.SourceCodeLine = 818;
    SHARE_VOLUME_MUTE_IS_ON [ SHARE]  .Value = (ushort) ( ROOM_VOLUME_MUTE_IS_ON[ ROOM ] .Value ) ; 
    
    }
    
private void UPDATESHARE (  SplusExecutionContext __context__ ) 
    { 
    ushort ITEM = 0;
    ushort ROOM = 0;
    
    
    __context__.SourceCodeLine = 825;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (__SHAREABLE_ROOMS__ == ""))  ) ) 
        { 
        __context__.SourceCodeLine = 827;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHAREABLE_ROOMS  != ""))  ) ) 
            { 
            __context__.SourceCodeLine = 829;
            __SHAREABLE_ROOMS__  .UpdateValue ( SHAREABLE_ROOMS  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 833;
            __SHAREABLE_ROOMS__  .UpdateValue ( __ROOMS__  ) ; 
            } 
        
        } 
    
    __context__.SourceCodeLine = 837;
    SHARES_SIZE  .Value = (ushort) ( Functions.Length( __SHAREABLE_ROOMS__ ) ) ; 
    __context__.SourceCodeLine = 839;
    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
    ushort __FN_FOREND_VAL__1 = (ushort)SHARES_SIZE  .Value; 
    int __FN_FORSTEP_VAL__1 = (int)1; 
    for ( ITEM  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ITEM  >= __FN_FORSTART_VAL__1) && (ITEM  <= __FN_FOREND_VAL__1) ) : ( (ITEM  <= __FN_FORSTART_VAL__1) && (ITEM  >= __FN_FOREND_VAL__1) ) ; ITEM  += (ushort)__FN_FORSTEP_VAL__1) 
        { 
        __context__.SourceCodeLine = 841;
        ROOM = (ushort) ( Byte( __SHAREABLE_ROOMS__ , (int)( ITEM ) ) ) ; 
        __context__.SourceCodeLine = 842;
        ROOM = (ushort) ( IDTOINDEX( __context__ , (ushort)( ROOM ) ) ) ; 
        __context__.SourceCodeLine = 844;
        __SHARE_ROOM__ [ ITEM] = (ushort) ( ROOM ) ; 
        __context__.SourceCodeLine = 845;
        __ROOM_SHARE__ [ ROOM] = (ushort) ( ITEM ) ; 
        __context__.SourceCodeLine = 847;
        SHARE_ROOM_NAME_IS [ ITEM]  .UpdateValue ( ROOM_NAME_IS [ ROOM ]  ) ; 
        __context__.SourceCodeLine = 849;
        UPDATESHARESOURCE (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 850;
        UPDATESHAREVOLUME (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 851;
        UPDATESHAREVOLUMEMUTE (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 852;
        UPDATESHAREVISIBLE (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 839;
        } 
    
    
    }
    
object ROOM_IS_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 861;
        UPDATEMOVEROOM (  __context__  ) ; 
        __context__.SourceCodeLine = 862;
        UPDATEWATCHLISTEN (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOURCE_IS_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 867;
        UPDATESHARE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

ushort [] __ROOM_SOURCE_WAS__;
object ROOM_SOURCE_IS_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ROOM = 0;
        ushort SOURCE = 0;
        ushort ITEM = 0;
        
        
        __context__.SourceCodeLine = 876;
        ROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 878;
        UPDATEMOVESOURCE (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 879;
        UPDATESHARESOURCE (  __context__ , (ushort)( ROOM )) ; 
        __context__.SourceCodeLine = 881;
        SOURCE = (ushort) ( __ROOM_SOURCE_WAS__[ ROOM ] ) ; 
        __context__.SourceCodeLine = 883;
        ITEM = (ushort) ( SOURCETOWATCH( __context__ , (ushort)( SOURCE ) ) ) ; 
        __context__.SourceCodeLine = 884;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEM > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 886;
            UPDATEWATCH (  __context__ , (ushort)( SOURCE )) ; 
            } 
        
        __context__.SourceCodeLine = 889;
        ITEM = (ushort) ( SOURCETOLISTEN( __context__ , (ushort)( SOURCE ) ) ) ; 
        __context__.SourceCodeLine = 890;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEM > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 892;
            UPDATELISTEN (  __context__ , (ushort)( SOURCE )) ; 
            } 
        
        __context__.SourceCodeLine = 895;
        SOURCE = (ushort) ( IDTOINDEX( __context__ , (ushort)( ROOM_SOURCE_IS[ ROOM ] .UshortValue ) ) ) ; 
        __context__.SourceCodeLine = 896;
        __ROOM_SOURCE_WAS__ [ ROOM] = (ushort) ( SOURCE ) ; 
        __context__.SourceCodeLine = 898;
        ITEM = (ushort) ( SOURCETOWATCH( __context__ , (ushort)( SOURCE ) ) ) ; 
        __context__.SourceCodeLine = 899;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEM > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 901;
            UPDATEWATCH (  __context__ , (ushort)( SOURCE )) ; 
            } 
        
        __context__.SourceCodeLine = 904;
        ITEM = (ushort) ( SOURCETOLISTEN( __context__ , (ushort)( SOURCE ) ) ) ; 
        __context__.SourceCodeLine = 905;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEM > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 907;
            UPDATELISTEN (  __context__ , (ushort)( SOURCE )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_VOLUME_IS_OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ROOM = 0;
        
        
        __context__.SourceCodeLine = 915;
        ROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 917;
        UPDATESHAREVOLUME (  __context__ , (ushort)( ROOM )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_VOLUME_MUTE_IS_ON_OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort ROOM = 0;
        
        
        __context__.SourceCodeLine = 924;
        ROOM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 926;
        UPDATESHAREVOLUMEMUTE (  __context__ , (ushort)( ROOM )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void __INIT__ (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 934;
    __ROOMS__  .UpdateValue ( ""  ) ; 
    __context__.SourceCodeLine = 937;
    Functions.SetArray (  ref __MOVE_ROOM__ , (ushort)0) ; 
    __context__.SourceCodeLine = 938;
    Functions.SetArray (  ref __ROOM_MOVE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 939;
    Functions.SetArray (  ref __WATCH_SOURCE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 940;
    Functions.SetArray (  ref __SOURCE_WATCH__ , (ushort)0) ; 
    __context__.SourceCodeLine = 941;
    Functions.SetArray (  ref __LISTEN_SOURCE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 942;
    Functions.SetArray (  ref __SOURCE_LISTEN__ , (ushort)0) ; 
    __context__.SourceCodeLine = 943;
    Functions.SetArray (  ref __SHARE_ROOM__ , (ushort)0) ; 
    __context__.SourceCodeLine = 944;
    Functions.SetArray (  ref __ROOM_SHARE__ , (ushort)0) ; 
    __context__.SourceCodeLine = 945;
    Functions.SetArray (  ref __ROOM_SOURCE_WAS__ , (ushort)0) ; 
    __context__.SourceCodeLine = 947;
    UPDATEMOVE (  __context__  ) ; 
    __context__.SourceCodeLine = 948;
    UPDATEWATCHLISTEN (  __context__  ) ; 
    __context__.SourceCodeLine = 949;
    UPDATESHARE (  __context__  ) ; 
    
    }
    
object INITIALIZE_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 954;
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
        
        __context__.SourceCodeLine = 962;
        WaitForInitializationComplete ( ) ; 
        
        
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
    __MOVE_ROOM__  = new ushort[ 49 ];
    __ROOM_MOVE__  = new ushort[ 100 ];
    __WATCH_SOURCE__  = new ushort[ 49 ];
    __SOURCE_WATCH__  = new ushort[ 100 ];
    __LISTEN_SOURCE__  = new ushort[ 49 ];
    __SOURCE_LISTEN__  = new ushort[ 100 ];
    __SHARE_ROOM__  = new ushort[ 49 ];
    __ROOM_SHARE__  = new ushort[ 100 ];
    __ROOM_SOURCE_WAS__  = new ushort[ 100 ];
    __ROOM_SOURCES__  = new ushort[ 100,100 ];
    __ROOMS__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 99, this );
    __SHAREABLE_ROOMS__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 99, this );
    __SOURCES__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 99, this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    MOVE_ROOM = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        MOVE_ROOM[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MOVE_ROOM__DigitalInput__ + i, MOVE_ROOM__DigitalInput__, this );
        m_DigitalInputList.Add( MOVE_ROOM__DigitalInput__ + i, MOVE_ROOM[i+1] );
    }
    
    WATCH_SOURCE = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        WATCH_SOURCE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( WATCH_SOURCE__DigitalInput__ + i, WATCH_SOURCE__DigitalInput__, this );
        m_DigitalInputList.Add( WATCH_SOURCE__DigitalInput__ + i, WATCH_SOURCE[i+1] );
    }
    
    LISTEN_SOURCE = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        LISTEN_SOURCE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( LISTEN_SOURCE__DigitalInput__ + i, LISTEN_SOURCE__DigitalInput__, this );
        m_DigitalInputList.Add( LISTEN_SOURCE__DigitalInput__ + i, LISTEN_SOURCE[i+1] );
    }
    
    SHARE_SOURCE = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_SOURCE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SHARE_SOURCE__DigitalInput__ + i, SHARE_SOURCE__DigitalInput__, this );
        m_DigitalInputList.Add( SHARE_SOURCE__DigitalInput__ + i, SHARE_SOURCE[i+1] );
    }
    
    SHARE_POWER_OFF = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_POWER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SHARE_POWER_OFF__DigitalInput__ + i, SHARE_POWER_OFF__DigitalInput__, this );
        m_DigitalInputList.Add( SHARE_POWER_OFF__DigitalInput__ + i, SHARE_POWER_OFF[i+1] );
    }
    
    SHARE_VOLUME_UP = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_VOLUME_UP[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SHARE_VOLUME_UP__DigitalInput__ + i, SHARE_VOLUME_UP__DigitalInput__, this );
        m_DigitalInputList.Add( SHARE_VOLUME_UP__DigitalInput__ + i, SHARE_VOLUME_UP[i+1] );
    }
    
    SHARE_VOLUME_DOWN = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_VOLUME_DOWN[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SHARE_VOLUME_DOWN__DigitalInput__ + i, SHARE_VOLUME_DOWN__DigitalInput__, this );
        m_DigitalInputList.Add( SHARE_VOLUME_DOWN__DigitalInput__ + i, SHARE_VOLUME_DOWN[i+1] );
    }
    
    SHARE_VOLUME_MUTE_TOGGLE = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_VOLUME_MUTE_TOGGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SHARE_VOLUME_MUTE_TOGGLE__DigitalInput__ + i, SHARE_VOLUME_MUTE_TOGGLE__DigitalInput__, this );
        m_DigitalInputList.Add( SHARE_VOLUME_MUTE_TOGGLE__DigitalInput__ + i, SHARE_VOLUME_MUTE_TOGGLE[i+1] );
    }
    
    ROOM_VOLUME_MUTE_IS_ON = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_VOLUME_MUTE_IS_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_VOLUME_MUTE_IS_ON__DigitalInput__ + i, ROOM_VOLUME_MUTE_IS_ON__DigitalInput__, this );
        m_DigitalInputList.Add( ROOM_VOLUME_MUTE_IS_ON__DigitalInput__ + i, ROOM_VOLUME_MUTE_IS_ON[i+1] );
    }
    
    SOURCE_IN_USE = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        SOURCE_IN_USE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_IN_USE__DigitalInput__ + i, SOURCE_IN_USE__DigitalInput__, this );
        m_DigitalInputList.Add( SOURCE_IN_USE__DigitalInput__ + i, SOURCE_IN_USE[i+1] );
    }
    
    SOURCE_HAS_AUDIO = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        SOURCE_HAS_AUDIO[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_HAS_AUDIO__DigitalInput__ + i, SOURCE_HAS_AUDIO__DigitalInput__, this );
        m_DigitalInputList.Add( SOURCE_HAS_AUDIO__DigitalInput__ + i, SOURCE_HAS_AUDIO[i+1] );
    }
    
    SOURCE_HAS_VIDEO = new InOutArray<DigitalInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        SOURCE_HAS_VIDEO[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_HAS_VIDEO__DigitalInput__ + i, SOURCE_HAS_VIDEO__DigitalInput__, this );
        m_DigitalInputList.Add( SOURCE_HAS_VIDEO__DigitalInput__ + i, SOURCE_HAS_VIDEO[i+1] );
    }
    
    MOVE_ROOM_MATCHES = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        MOVE_ROOM_MATCHES[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MOVE_ROOM_MATCHES__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MOVE_ROOM_MATCHES__DigitalOutput__ + i, MOVE_ROOM_MATCHES[i+1] );
    }
    
    WATCH_SOURCE_MATCHES = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        WATCH_SOURCE_MATCHES[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( WATCH_SOURCE_MATCHES__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( WATCH_SOURCE_MATCHES__DigitalOutput__ + i, WATCH_SOURCE_MATCHES[i+1] );
    }
    
    WATCH_SOURCE_IN_USE = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        WATCH_SOURCE_IN_USE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( WATCH_SOURCE_IN_USE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( WATCH_SOURCE_IN_USE__DigitalOutput__ + i, WATCH_SOURCE_IN_USE[i+1] );
    }
    
    LISTEN_SOURCE_MATCHES = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        LISTEN_SOURCE_MATCHES[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LISTEN_SOURCE_MATCHES__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LISTEN_SOURCE_MATCHES__DigitalOutput__ + i, LISTEN_SOURCE_MATCHES[i+1] );
    }
    
    LISTEN_SOURCE_IN_USE = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        LISTEN_SOURCE_IN_USE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LISTEN_SOURCE_IN_USE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LISTEN_SOURCE_IN_USE__DigitalOutput__ + i, LISTEN_SOURCE_IN_USE[i+1] );
    }
    
    SHARE_VISIBLE = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_VISIBLE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SHARE_VISIBLE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SHARE_VISIBLE__DigitalOutput__ + i, SHARE_VISIBLE[i+1] );
    }
    
    SHARE_SOURCE_MATCHES = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_SOURCE_MATCHES[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SHARE_SOURCE_MATCHES__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SHARE_SOURCE_MATCHES__DigitalOutput__ + i, SHARE_SOURCE_MATCHES[i+1] );
    }
    
    SHARE_POWER_IS_ON = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_POWER_IS_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SHARE_POWER_IS_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SHARE_POWER_IS_ON__DigitalOutput__ + i, SHARE_POWER_IS_ON[i+1] );
    }
    
    SHARE_VOLUME_MUTE_IS_ON = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_VOLUME_MUTE_IS_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SHARE_VOLUME_MUTE_IS_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SHARE_VOLUME_MUTE_IS_ON__DigitalOutput__ + i, SHARE_VOLUME_MUTE_IS_ON[i+1] );
    }
    
    ROOM_POWER_OFF = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_POWER_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_POWER_OFF__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ROOM_POWER_OFF__DigitalOutput__ + i, ROOM_POWER_OFF[i+1] );
    }
    
    ROOM_VOLUME_UP = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_VOLUME_UP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_VOLUME_UP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ROOM_VOLUME_UP__DigitalOutput__ + i, ROOM_VOLUME_UP[i+1] );
    }
    
    ROOM_VOLUME_DOWN = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_VOLUME_DOWN[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_VOLUME_DOWN__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ROOM_VOLUME_DOWN__DigitalOutput__ + i, ROOM_VOLUME_DOWN[i+1] );
    }
    
    ROOM_VOLUME_MUTE_TOGGLE = new InOutArray<DigitalOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_VOLUME_MUTE_TOGGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_VOLUME_MUTE_TOGGLE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ROOM_VOLUME_MUTE_TOGGLE__DigitalOutput__ + i, ROOM_VOLUME_MUTE_TOGGLE[i+1] );
    }
    
    ROOM_IS = new Crestron.Logos.SplusObjects.AnalogInput( ROOM_IS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( ROOM_IS__AnalogSerialInput__, ROOM_IS );
    
    SOURCE_IS = new Crestron.Logos.SplusObjects.AnalogInput( SOURCE_IS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SOURCE_IS__AnalogSerialInput__, SOURCE_IS );
    
    ROOM_SOURCE_IS = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_SOURCE_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( ROOM_SOURCE_IS__AnalogSerialInput__ + i, ROOM_SOURCE_IS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( ROOM_SOURCE_IS__AnalogSerialInput__ + i, ROOM_SOURCE_IS[i+1] );
    }
    
    ROOM_VOLUME_IS = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_VOLUME_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( ROOM_VOLUME_IS__AnalogSerialInput__ + i, ROOM_VOLUME_IS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( ROOM_VOLUME_IS__AnalogSerialInput__ + i, ROOM_VOLUME_IS[i+1] );
    }
    
    SOURCE_ICON_IS = new InOutArray<AnalogInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        SOURCE_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( SOURCE_ICON_IS__AnalogSerialInput__ + i, SOURCE_ICON_IS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SOURCE_ICON_IS__AnalogSerialInput__ + i, SOURCE_ICON_IS[i+1] );
    }
    
    MOVES_SIZE = new Crestron.Logos.SplusObjects.AnalogOutput( MOVES_SIZE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( MOVES_SIZE__AnalogSerialOutput__, MOVES_SIZE );
    
    WATCHES_SIZE = new Crestron.Logos.SplusObjects.AnalogOutput( WATCHES_SIZE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( WATCHES_SIZE__AnalogSerialOutput__, WATCHES_SIZE );
    
    LISTENS_SIZE = new Crestron.Logos.SplusObjects.AnalogOutput( LISTENS_SIZE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LISTENS_SIZE__AnalogSerialOutput__, LISTENS_SIZE );
    
    SHARES_SIZE = new Crestron.Logos.SplusObjects.AnalogOutput( SHARES_SIZE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SHARES_SIZE__AnalogSerialOutput__, SHARES_SIZE );
    
    MOVE_SOURCE_ICON_IS = new InOutArray<AnalogOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        MOVE_SOURCE_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MOVE_SOURCE_ICON_IS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MOVE_SOURCE_ICON_IS__AnalogSerialOutput__ + i, MOVE_SOURCE_ICON_IS[i+1] );
    }
    
    WATCH_SOURCE_ICON_IS = new InOutArray<AnalogOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        WATCH_SOURCE_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( WATCH_SOURCE_ICON_IS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( WATCH_SOURCE_ICON_IS__AnalogSerialOutput__ + i, WATCH_SOURCE_ICON_IS[i+1] );
    }
    
    LISTEN_SOURCE_ICON_IS = new InOutArray<AnalogOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        LISTEN_SOURCE_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LISTEN_SOURCE_ICON_IS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LISTEN_SOURCE_ICON_IS__AnalogSerialOutput__ + i, LISTEN_SOURCE_ICON_IS[i+1] );
    }
    
    SHARE_SOURCE_ICON_IS = new InOutArray<AnalogOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_SOURCE_ICON_IS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SHARE_SOURCE_ICON_IS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SHARE_SOURCE_ICON_IS__AnalogSerialOutput__ + i, SHARE_SOURCE_ICON_IS[i+1] );
    }
    
    DEFAULT_AVAILABLE_ROOMS = new Crestron.Logos.SplusObjects.StringInput( DEFAULT_AVAILABLE_ROOMS__AnalogSerialInput__, 99, this );
    m_StringInputList.Add( DEFAULT_AVAILABLE_ROOMS__AnalogSerialInput__, DEFAULT_AVAILABLE_ROOMS );
    
    DEFAULT_AVAILABLE_SOURCES = new Crestron.Logos.SplusObjects.StringInput( DEFAULT_AVAILABLE_SOURCES__AnalogSerialInput__, 99, this );
    m_StringInputList.Add( DEFAULT_AVAILABLE_SOURCES__AnalogSerialInput__, DEFAULT_AVAILABLE_SOURCES );
    
    ROOM_NAME_IS = new InOutArray<StringInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringInput( ROOM_NAME_IS__AnalogSerialInput__ + i, ROOM_NAME_IS__AnalogSerialInput__, 48, this );
        m_StringInputList.Add( ROOM_NAME_IS__AnalogSerialInput__ + i, ROOM_NAME_IS[i+1] );
    }
    
    ROOM_SOURCES_IS = new InOutArray<StringInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_SOURCES_IS[i+1] = new Crestron.Logos.SplusObjects.StringInput( ROOM_SOURCES_IS__AnalogSerialInput__ + i, ROOM_SOURCES_IS__AnalogSerialInput__, 48, this );
        m_StringInputList.Add( ROOM_SOURCES_IS__AnalogSerialInput__ + i, ROOM_SOURCES_IS[i+1] );
    }
    
    SOURCE_NAME_IS = new InOutArray<StringInput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        SOURCE_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringInput( SOURCE_NAME_IS__AnalogSerialInput__ + i, SOURCE_NAME_IS__AnalogSerialInput__, 48, this );
        m_StringInputList.Add( SOURCE_NAME_IS__AnalogSerialInput__ + i, SOURCE_NAME_IS[i+1] );
    }
    
    ROOM_SET = new Crestron.Logos.SplusObjects.StringOutput( ROOM_SET__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ROOM_SET__AnalogSerialOutput__, ROOM_SET );
    
    CONTROL_SOURCE_SET = new Crestron.Logos.SplusObjects.StringOutput( CONTROL_SOURCE_SET__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONTROL_SOURCE_SET__AnalogSerialOutput__, CONTROL_SOURCE_SET );
    
    MOVE_ROOM_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        MOVE_ROOM_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MOVE_ROOM_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MOVE_ROOM_NAME_IS__AnalogSerialOutput__ + i, MOVE_ROOM_NAME_IS[i+1] );
    }
    
    MOVE_SOURCE_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        MOVE_SOURCE_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( MOVE_SOURCE_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( MOVE_SOURCE_NAME_IS__AnalogSerialOutput__ + i, MOVE_SOURCE_NAME_IS[i+1] );
    }
    
    WATCH_SOURCE_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        WATCH_SOURCE_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( WATCH_SOURCE_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( WATCH_SOURCE_NAME_IS__AnalogSerialOutput__ + i, WATCH_SOURCE_NAME_IS[i+1] );
    }
    
    WATCH_SOURCE_ROOM_NAMES_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        WATCH_SOURCE_ROOM_NAMES_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( WATCH_SOURCE_ROOM_NAMES_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( WATCH_SOURCE_ROOM_NAMES_IS__AnalogSerialOutput__ + i, WATCH_SOURCE_ROOM_NAMES_IS[i+1] );
    }
    
    LISTEN_SOURCE_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        LISTEN_SOURCE_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LISTEN_SOURCE_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LISTEN_SOURCE_NAME_IS__AnalogSerialOutput__ + i, LISTEN_SOURCE_NAME_IS[i+1] );
    }
    
    LISTEN_SOURCE_ROOM_NAMES_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        LISTEN_SOURCE_ROOM_NAMES_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LISTEN_SOURCE_ROOM_NAMES_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LISTEN_SOURCE_ROOM_NAMES_IS__AnalogSerialOutput__ + i, LISTEN_SOURCE_ROOM_NAMES_IS[i+1] );
    }
    
    SHARE_ROOM_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_ROOM_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SHARE_ROOM_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SHARE_ROOM_NAME_IS__AnalogSerialOutput__ + i, SHARE_ROOM_NAME_IS[i+1] );
    }
    
    SHARE_SOURCE_NAME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_SOURCE_NAME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SHARE_SOURCE_NAME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SHARE_SOURCE_NAME_IS__AnalogSerialOutput__ + i, SHARE_SOURCE_NAME_IS[i+1] );
    }
    
    SHARE_VOLUME_IS = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        SHARE_VOLUME_IS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SHARE_VOLUME_IS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SHARE_VOLUME_IS__AnalogSerialOutput__ + i, SHARE_VOLUME_IS[i+1] );
    }
    
    ROOM_SOURCE = new InOutArray<StringOutput>( 99, this );
    for( uint i = 0; i < 99; i++ )
    {
        ROOM_SOURCE[i+1] = new Crestron.Logos.SplusObjects.StringOutput( ROOM_SOURCE__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( ROOM_SOURCE__AnalogSerialOutput__ + i, ROOM_SOURCE[i+1] );
    }
    
    ROOMS = new StringParameter( ROOMS__Parameter__, this );
    m_ParameterList.Add( ROOMS__Parameter__, ROOMS );
    
    SHAREABLE_ROOMS = new StringParameter( SHAREABLE_ROOMS__Parameter__, this );
    m_ParameterList.Add( SHAREABLE_ROOMS__Parameter__, SHAREABLE_ROOMS );
    
    
    for( uint i = 0; i < 48; i++ )
        MOVE_ROOM[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MOVE_ROOM_OnPush_0, false ) );
        
    for( uint i = 0; i < 48; i++ )
        WATCH_SOURCE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( WATCH_SOURCE_OnPush_1, false ) );
        
    for( uint i = 0; i < 48; i++ )
        LISTEN_SOURCE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( LISTEN_SOURCE_OnPush_2, false ) );
        
    for( uint i = 0; i < 48; i++ )
        SHARE_SOURCE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SHARE_SOURCE_OnPush_3, false ) );
        
    for( uint i = 0; i < 48; i++ )
        SHARE_POWER_OFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SHARE_POWER_OFF_OnPush_4, false ) );
        
    for( uint i = 0; i < 48; i++ )
        SHARE_VOLUME_UP[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( SHARE_VOLUME_UP_OnChange_5, false ) );
        
    for( uint i = 0; i < 48; i++ )
        SHARE_VOLUME_DOWN[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( SHARE_VOLUME_DOWN_OnChange_6, false ) );
        
    for( uint i = 0; i < 48; i++ )
        SHARE_VOLUME_MUTE_TOGGLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SHARE_VOLUME_MUTE_TOGGLE_OnPush_7, false ) );
        
    ROOM_IS.OnAnalogChange.Add( new InputChangeHandlerWrapper( ROOM_IS_OnChange_8, false ) );
    SOURCE_IS.OnAnalogChange.Add( new InputChangeHandlerWrapper( SOURCE_IS_OnChange_9, false ) );
    for( uint i = 0; i < 99; i++ )
        ROOM_SOURCE_IS[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( ROOM_SOURCE_IS_OnChange_10, false ) );
        
    for( uint i = 0; i < 99; i++ )
        ROOM_VOLUME_IS[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( ROOM_VOLUME_IS_OnChange_11, false ) );
        
    for( uint i = 0; i < 99; i++ )
        ROOM_VOLUME_MUTE_IS_ON[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( ROOM_VOLUME_MUTE_IS_ON_OnChange_12, false ) );
        
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_13, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_ROOMS_SOURCES_CONTROLLER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint MOVE_ROOM__DigitalInput__ = 1;
const uint WATCH_SOURCE__DigitalInput__ = 49;
const uint LISTEN_SOURCE__DigitalInput__ = 97;
const uint SHARE_SOURCE__DigitalInput__ = 145;
const uint SHARE_POWER_OFF__DigitalInput__ = 193;
const uint SHARE_VOLUME_UP__DigitalInput__ = 241;
const uint SHARE_VOLUME_DOWN__DigitalInput__ = 289;
const uint SHARE_VOLUME_MUTE_TOGGLE__DigitalInput__ = 337;
const uint ROOM_VOLUME_MUTE_IS_ON__DigitalInput__ = 385;
const uint SOURCE_IN_USE__DigitalInput__ = 484;
const uint SOURCE_HAS_AUDIO__DigitalInput__ = 583;
const uint SOURCE_HAS_VIDEO__DigitalInput__ = 682;
const uint MOVE_ROOM_MATCHES__DigitalOutput__ = 0;
const uint WATCH_SOURCE_MATCHES__DigitalOutput__ = 48;
const uint WATCH_SOURCE_IN_USE__DigitalOutput__ = 96;
const uint LISTEN_SOURCE_MATCHES__DigitalOutput__ = 144;
const uint LISTEN_SOURCE_IN_USE__DigitalOutput__ = 192;
const uint SHARE_VISIBLE__DigitalOutput__ = 240;
const uint SHARE_SOURCE_MATCHES__DigitalOutput__ = 288;
const uint SHARE_POWER_IS_ON__DigitalOutput__ = 336;
const uint SHARE_VOLUME_MUTE_IS_ON__DigitalOutput__ = 384;
const uint ROOM_POWER_OFF__DigitalOutput__ = 432;
const uint ROOM_VOLUME_UP__DigitalOutput__ = 531;
const uint ROOM_VOLUME_DOWN__DigitalOutput__ = 630;
const uint ROOM_VOLUME_MUTE_TOGGLE__DigitalOutput__ = 729;
const uint ROOM_IS__AnalogSerialInput__ = 0;
const uint SOURCE_IS__AnalogSerialInput__ = 1;
const uint DEFAULT_AVAILABLE_ROOMS__AnalogSerialInput__ = 2;
const uint DEFAULT_AVAILABLE_SOURCES__AnalogSerialInput__ = 3;
const uint ROOM_SOURCE_IS__AnalogSerialInput__ = 4;
const uint ROOM_VOLUME_IS__AnalogSerialInput__ = 103;
const uint SOURCE_ICON_IS__AnalogSerialInput__ = 202;
const uint ROOM_SET__AnalogSerialOutput__ = 0;
const uint CONTROL_SOURCE_SET__AnalogSerialOutput__ = 1;
const uint MOVES_SIZE__AnalogSerialOutput__ = 2;
const uint WATCHES_SIZE__AnalogSerialOutput__ = 3;
const uint LISTENS_SIZE__AnalogSerialOutput__ = 4;
const uint SHARES_SIZE__AnalogSerialOutput__ = 5;
const uint MOVE_SOURCE_ICON_IS__AnalogSerialOutput__ = 6;
const uint WATCH_SOURCE_ICON_IS__AnalogSerialOutput__ = 54;
const uint LISTEN_SOURCE_ICON_IS__AnalogSerialOutput__ = 102;
const uint SHARE_SOURCE_ICON_IS__AnalogSerialOutput__ = 150;
const uint ROOM_NAME_IS__AnalogSerialInput__ = 301;
const uint ROOM_SOURCES_IS__AnalogSerialInput__ = 400;
const uint SOURCE_NAME_IS__AnalogSerialInput__ = 499;
const uint MOVE_ROOM_NAME_IS__AnalogSerialOutput__ = 198;
const uint MOVE_SOURCE_NAME_IS__AnalogSerialOutput__ = 246;
const uint WATCH_SOURCE_NAME_IS__AnalogSerialOutput__ = 294;
const uint WATCH_SOURCE_ROOM_NAMES_IS__AnalogSerialOutput__ = 342;
const uint LISTEN_SOURCE_NAME_IS__AnalogSerialOutput__ = 390;
const uint LISTEN_SOURCE_ROOM_NAMES_IS__AnalogSerialOutput__ = 438;
const uint SHARE_ROOM_NAME_IS__AnalogSerialOutput__ = 486;
const uint SHARE_SOURCE_NAME_IS__AnalogSerialOutput__ = 534;
const uint SHARE_VOLUME_IS__AnalogSerialOutput__ = 582;
const uint ROOM_SOURCE__AnalogSerialOutput__ = 630;
const uint ROOMS__Parameter__ = 10;
const uint SHAREABLE_ROOMS__Parameter__ = 11;

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
