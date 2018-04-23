namespace SonosLibrary_v2_3;
        // class declarations
         class SonosDIDL;
         class DeviceDriver;
         class JoinUI;
         class eTrackType;
         class SonosTrack;
         class SystemDriver;
         class UIBrowseList;
         class UIBrowseListItems;
         class GroupingUI;
         class SonosGroup;
         class PlaybackMetadataMessageStructure;
         class Id;
         class Service;
         class Container;
         class TrackId;
         class ArtistId;
         class Artist;
         class AlbumId;
         class AlbumArtist;
         class Album;
         class Track;
         class CurrentItem;
         class NextItemArtist;
         class NextItemAlbumArtist;
         class NextItemAlbum;
         class NextItemTrack;
         class NextItem;
         class MetadataRootObject;
         class Logger;
         class XMLStructures;
         class Envelope;
         class Body;
         class BrowseReponse;
         class GroupCoordinatorChangeMessageStructure;
         class GroupCoordinatorChangeMessageRootObject;
         class SystemManager;
         class SystemStorageStructures;
         class DeviceControl;
         class MessageRequestStructure;
         class browseRequest;
         class SonosItem;
         class MenuClass;
         class TextLinesClass;
         class MediaPlayerClass;
         class DeviceMediaPlayer;
         class DeviceMediaMenu;
         class SystemDriverInitializationCompleteEventArgs;
         class OfflineStateChangedEventArgs;
         class ConnectionStateChangedEventArgs;
         class GroupTopologyStartedEventArgs;
         class GroupTopologyCompleteEventArgs;
         class DiscoveryStartedEventArgs;
         class DiscoveryCompleteEventArgs;
         class GettingFavoritesEventArgs;
         class FavoritesCompleteEventArgs;
         class SystemDriverCompleteEventArgs;
         class ConnectionCompletedEventArgs;
         class GroupCoordinatorChangeEventArgs;
         class GroupVolumeChangeEventArgs;
         class PlaybackMetaDataChangeEventArgs;
         class PlaybackErrorEventArgs;
         class PlaybackStatusChangeEventArgs;
         class GlobalErrorEventArgs;
         class BusyEventArgs;
         class ClearBusyEventArgs;
         class SonosPlayer;
         class PlaybackStatusMessageStructure;
         class PlayModes;
         class AvailablePlaybackActions;
         class PlaybackStatusRootObject;
     class SonosDIDL 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING AlbumArtURI[];
        STRING Title[];
        STRING Artist[];
        STRING Album[];
        STRING Uri[];
        STRING Description[];
        SIGNED_LONG_INTEGER Ordinal;
    };

     class DeviceDriver 
    {
        // class delegates

        // class events
        EventHandler OfflineStateChangedEvent ( DeviceDriver sender, OfflineStateChangedEventArgs e );
        EventHandler ConnectionCompletedEvent ( DeviceDriver sender, ConnectionCompletedEventArgs e );
        EventHandler GroupCoordinatorChangeEvent ( DeviceDriver sender, GroupCoordinatorChangeEventArgs e );
        EventHandler GroupVolumeChangeEvent ( DeviceDriver sender, GroupVolumeChangeEventArgs e );
        EventHandler PlaybackMetaDataChangeEvent ( DeviceDriver sender, PlaybackMetaDataChangeEventArgs e );
        EventHandler PlaybackErrorEvent ( DeviceDriver sender, PlaybackErrorEventArgs e );
        EventHandler PlaybackStatusChangeEvent ( DeviceDriver sender, PlaybackStatusChangeEventArgs e );
        EventHandler GlobalErrorEvent ( DeviceDriver sender, GlobalErrorEventArgs e );

        // class functions
        FUNCTION InitializeCommunication ();
        FUNCTION TriggerPlaybackErrorEvent ( STRING error );
        FUNCTION TriggerGlobalErrorEvent ( STRING error );
        FUNCTION PrepareSend ( STRING command );
        FUNCTION SubscribeToPlayback ();
        FUNCTION UnsubscribeToPlayback ();
        FUNCTION Play ();
        FUNCTION Pause ();
        FUNCTION NextTrack ();
        FUNCTION PreviousTrack ();
        FUNCTION GetPlaybackStatus ();
        FUNCTION SubscribeToGroupVolume ();
        FUNCTION UnsubscribeToGroupVolume ();
        FUNCTION GetVolume ();
        FUNCTION SetVolume ( SIGNED_LONG_INTEGER volumelevel );
        FUNCTION VolumeUp ();
        FUNCTION VolumeDown ();
        FUNCTION Mute ();
        FUNCTION Unmute ();
        FUNCTION SubscribeToPlaybackMetadata ();
        FUNCTION UnsubscribeToPlaybackMetadata ();
        FUNCTION PlayFavorite ( SonosItem favorite );
        FUNCTION SetAVTransportURI ( SonosItem favorite );
        FUNCTION GetPositionInfo ();
        FUNCTION GetNowPlayingMetadata ( STRING paramTrackId );
        FUNCTION GetNowPlayingMediaInfo ();
        FUNCTION CallAVTransportPlay ();
        FUNCTION SetPlaylistAVTransportURI ( SonosItem favorite );
        FUNCTION SetAVTransportURItoPlayerQueue ();
        FUNCTION SendSeekTransport ( STRING target );
        FUNCTION ResponseHandler ( STRING incomingResponse );
        FUNCTION ProcessResponse ( STRING response );
        FUNCTION SubscribeToAVTransportLastChange ();
        FUNCTION UnsubscribeToAVTransportLastChange ( STRING paramSid );
        static STRING_FUNCTION HtmlEncode ( STRING s );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING GroupId[];
        STRING GroupName[];
        STRING PlayerId[];
        STRING HouseholdId[];
        STRING WebsocketUrl[];
        STRING GroupCoordinatorName[];
        STRING GroupCoordinatorUUID[];
        STRING DeviceUuid[];
        STRING RoomName[];
        STRING DeviceDescriptionUrl[];
        STRING DeviceType[];
        STRING ModelNumber[];
        STRING ModelName[];
        STRING SoftwareVersion[];
        STRING HardwareVersion[];
        STRING SerialNumber[];
        STRING displaySoftwareVersion[];
        SIGNED_LONG_INTEGER VolumeLevel;
        SIGNED_LONG_INTEGER NowPlayingTrackLengthMilliseconds;
        SIGNED_LONG_INTEGER NowPlayingTrackPositionMilliseconds;
        STRING PlaybackState[];
        STRING PlaybackError[];
        STRING NowPlayingContainerName[];
        STRING NowPlayingProviderName[];
        STRING NowPlayingTrackName[];
        STRING NowPlayingArtist[];
        STRING NowPlayingAlbum[];
        STRING NowPlayingTrackNumber[];
        STRING NowPlayingGenre[];
        STRING NowPlayingImageURL[];
        eTrackType NowPlayingType;
        STRING NextItemTrackName[];
        STRING NextItemArtist[];
        STRING NextItemAlbum[];
        STRING NextItemImageURL[];

        // class properties
    };

     class JoinUI 
    {
        // class delegates
        delegate FUNCTION DelegateFn ( );

        // class events
        EventHandler BusyEvent ( JoinUI sender, BusyEventArgs e );
        EventHandler ClearBusyEvent ( JoinUI sender, ClearBusyEventArgs e );

        // class functions
        FUNCTION GetGroupInfo ();
        FUNCTION GetFavoriteInfo ();
        FUNCTION GetPlaybackStatus ();
        FUNCTION GetPlaybackMetadata ();
        FUNCTION GetVolumeInfo ();
        FUNCTION GetPlaybackError ();
        FUNCTION SubscribeToEvents ();
        FUNCTION UnsubscribeToEvents ();
        FUNCTION TriggerBusyEvent ( STRING result );
        FUNCTION TriggerClearBusyEvent ( STRING result );
        FUNCTION SetPlayer ( SIGNED_LONG_INTEGER grouptoselect );
        FUNCTION SetGroupByName ( STRING paramGroupName );
        FUNCTION SetPlayerByName ( STRING playertoselect );
        FUNCTION PlayFavorite ( SIGNED_LONG_INTEGER favoriteselected );
        FUNCTION PlayFavoriteByName ( STRING favoritetoselect );
        FUNCTION Play ();
        FUNCTION Pause ();
        FUNCTION NextTrack ();
        FUNCTION PreviousTrack ();
        FUNCTION VolumeUp ();
        FUNCTION VolumeDown ();
        FUNCTION SetVolumeLevel ( INTEGER volumelevel );
        FUNCTION Mute ();
        FUNCTION Unmute ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        SystemDriver SystemDriverInstance;
        DeviceDriver DeviceInstance;
        SonosItem FavoriteInstance;
        STRING ListOfGroupNames[][];
        INTEGER NumberOfGroups;
        STRING ListOfFavorites[][];
        STRING ListOfFavoritesDescriptions[][];
        STRING ListOfFavoritesImageURLs[][];
        INTEGER NumberOfFavorites;
        SIGNED_LONG_INTEGER SelectedGroup;
        STRING GroupName[];
        STRING GroupId[];
        STRING HouseholdId[];
        STRING WebsocketUrl[];
        SIGNED_LONG_INTEGER SelectedFavorite;
        STRING FavoriteName[];
        STRING FavoriteDescription[];
        STRING FavoriteImageURL[];
        STRING BusyStatus[];
        STRING DiscoveringGroups[];
        STRING GettingFavorites[];
        STRING SystemDriverComplete[];
        STRING IsPlaying[];
        STRING IsPaused[];
        STRING IsBuffering[];
        STRING IsIdle[];
        STRING NextTrackAvailable[];
        STRING PreviousTrackAvailable[];
        STRING ShowTrackProgress[];
        STRING SeekingAvailable[];
        STRING IsMuted[];
        STRING VolumeIsFixed[];
        STRING RepeatSupported[];
        STRING RepeatEnabled[];
        STRING RepeatOneSupported[];
        STRING RepeatOneEnabled[];
        STRING ShuffleSupported[];
        STRING ShuffleEnabled[];
        STRING CrossfadeSupported[];
        STRING CrossfadeEnabled[];
        INTEGER VolumeLevel;
        SIGNED_LONG_INTEGER NowPlayingTrackLengthMilliseconds;
        SIGNED_LONG_INTEGER NowPlayingTrackPositionMilliseconds;
        INTEGER NowPlayingTrackLengthSeconds;
        INTEGER NowPlayingTrackPositionSeconds;
        INTEGER NowPlayingTrackPositionGauge;
        STRING PlaybackState[];
        STRING PlaybackError[];
        STRING NowPlayingContainerName[];
        STRING NowPlayingProviderName[];
        STRING NowPlayingTrackName[];
        STRING NowPlayingArtist[];
        STRING NowPlayingAlbum[];
        STRING NowPlayingTrackNumber[];
        STRING NowPlayingGenre[];
        STRING NowPlayingImageURL[];
        STRING NowPlayingTrackLengthString[];
        STRING NowPlayingTrackPositionString[];

        // class properties
        DelegateProperty DelegateFn PlayerConnectionUpdate;
        DelegateProperty DelegateFn PlayerBusyUpdate;
        DelegateProperty DelegateFn BrowseListBusyUpdate;
        DelegateProperty DelegateFn DirectSourcesListUpdate;
        DelegateProperty DelegateFn GroupsListUpdate;
        DelegateProperty DelegateFn FavoritesListUpdate;
        DelegateProperty DelegateFn PlayersAndGroupsListUpdate;
        DelegateProperty DelegateFn PlayersListUpdate;
        DelegateProperty DelegateFn MusicSourcesListUpdate;
        DelegateProperty DelegateFn PlayerInfoUpdate;
        DelegateProperty DelegateFn FavoriteInfoUpdate;
        DelegateProperty DelegateFn PlayerStateUpdate;
        DelegateProperty DelegateFn PlayerNowPlayingInfoUpdate;
        DelegateProperty DelegateFn PlayerNowPlayingProgressUpdate;
        DelegateProperty DelegateFn PlayerVolumeUpdate;
        DelegateProperty DelegateFn PlayerPlaybackErrorUpdate;
        DelegateProperty DelegateFn BrowseListUpdate;
        STRING DefaultPlayerName[];
    };

    static class eTrackType // enum
    {
        static SIGNED_LONG_INTEGER AudioTrack;
        static SIGNED_LONG_INTEGER AudioBroadcast;
        static SIGNED_LONG_INTEGER AudioBook;
        static SIGNED_LONG_INTEGER Playlist;
    };

     class SonosTrack 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Uri[];
        STRING MetaData[];
        eTrackType TrackType;
    };

     class SystemDriver 
    {
        // class delegates
        delegate FUNCTION DelegateFn ( );

        // class events

        // class functions
        FUNCTION Initialize ();
        FUNCTION EnableLogger ();
        FUNCTION DisableLogger ();
        FUNCTION PrintTest ();
        FUNCTION PrintGroupTopology ();
        FUNCTION PrintPlayerList ();
        FUNCTION PrintDiscoveryInfo ();
        FUNCTION DiscoverGroups ();
        FUNCTION DiscoverGroupsBroadcast ();
        FUNCTION StopDiscovery ();
        FUNCTION StopBroadcastDiscovery ();
        FUNCTION ParseData ( STRING datastring );
        FUNCTION ClearSystemConfiguration ();
        FUNCTION AddPlayerToGroup ( STRING paramGroupCoordinatorUuid , STRING playerlocation );
        FUNCTION RemovePlayerFromGroup ( STRING playerlocation );
        FUNCTION GetNewSubscription ( DeviceControl control );
        FUNCTION SubscribeToGroupTopology ();
        FUNCTION CreateGroupInstances ();
        FUNCTION GetFavorites ();
        FUNCTION ParseFavorites ( STRING response );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING BusyStatus[];
        STRING DiscoveringGroups[];
        STRING GettingFavorites[];
        STRING SystemDriverComplete[];

        // class properties
        DelegateProperty DelegateFn PlayerBusyUpdate;
    };

     class GroupingUI 
    {
        // class delegates
        delegate FUNCTION DelegateFn ( );

        // class events

        // class functions
        FUNCTION GetGroupingInfo ();
        FUNCTION SubscribeToEvents ();
        FUNCTION UnsubscribeToEvents ();
        FUNCTION GetPlaybackMetadata ();
        FUNCTION GroupsListRefresh ();
        FUNCTION GroupsNowPlayingInfoRefresh ();
        FUNCTION GroupsPlaybackStatusRefresh ();
        FUNCTION PlayersListRefresh ();
        FUNCTION PlayersSelectedFeedbackRefresh ();
        FUNCTION UpdatePreviousListOfSelectedFeedback ();
        FUNCTION SetGroup ( SIGNED_LONG_INTEGER grouptoselect );
        FUNCTION UpdatePlayerSelectedFeedback ( SIGNED_LONG_INTEGER playertoupdate );
        FUNCTION AddOrRemovePlayers ();
        FUNCTION AddPlayerToGroup ( STRING playerlocation );
        FUNCTION RemovePlayerFromGroup ( STRING playerlocation );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        SystemDriver SystemDriverInstance;
        DeviceDriver DeviceInstance;
        STRING ListOfGroupNames[][];
        STRING ListOfNowPlayingInfo[][];
        STRING ListOfNowPlayingImageURL[][];
        STRING ListOfPlaybackStatus[][];
        INTEGER NumberOfGroups;
        INTEGER NumberOfPlayersInGroup[];
        STRING Player1Name[][];
        STRING Player2Name[][];
        STRING Player3Name[][];
        STRING Player4Name[][];
        STRING ListOfPlayerNames[][];
        STRING ListOfSelectedFeedback[][];
        STRING PreviousListOfSelectedFeedback[][];
        INTEGER NumberOfPlayers;
        STRING NowPlayingContainerName[];
        STRING NowPlayingProviderName[];
        STRING NowPlayingTrackName[];
        STRING NowPlayingArtist[];
        STRING NowPlayingAlbum[];
        STRING NowPlayingImageURL[];
        STRING BusyStatus[];
        STRING DiscoveringGroups[];
        STRING GettingFavorites[];
        STRING SystemDriverComplete[];

        // class properties
        DelegateProperty DelegateFn PlayerBusyUpdate;
        DelegateProperty DelegateFn GroupsListUpdate;
        DelegateProperty DelegateFn GroupsNowPlayingUpdate;
        DelegateProperty DelegateFn GroupsPlaybackStatusUpdate;
        DelegateProperty DelegateFn PlayersListUpdate;
        DelegateProperty DelegateFn PlayersSelectedUpdate;
        DelegateProperty DelegateFn NowPlayingInfoUpdate;
    };

     class SonosGroup 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING GroupName[];
        STRING GroupId[];
        STRING HouseholdId[];
        STRING WebsocketUrl[];
        STRING BaseUrl[];
        STRING Location[];
        STRING CoordinatorUUID[];
        STRING CoordinatorName[];
        STRING CoordinatorLocation[];

        // class properties
    };

     class PlaybackMetadataMessageStructure 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class Id 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING serviceId[];
        STRING objectId[];
        STRING accountId[];
    };

     class Service 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING id[];
        STRING name[];
    };

     class Container 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING name[];
        STRING type[];
        Id id;
        Service service;
    };

     class TrackId 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING serviceId[];
        STRING objectId[];
        STRING accountId[];
    };

     class ArtistId 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING serviceId[];
        STRING objectId[];
    };

     class Artist 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        ArtistId id;
        STRING name[];
    };

     class AlbumId 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING serviceId[];
        STRING objectId[];
    };

     class AlbumArtist 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING name[];
    };

     class Album 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        AlbumId id;
        STRING name[];
        AlbumArtist artist;
    };

     class Track 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING type[];
        TrackId id;
        STRING name[];
        Artist artist;
        Album album;
        STRING imageUrl[];
        SIGNED_LONG_INTEGER durationMillis;
        Service service;
    };

     class CurrentItem 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING id[];
        Track track;
    };

     class NextItemArtist 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING id[];
        STRING name[];
    };

     class NextItemAlbumArtist 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING name[];
    };

     class NextItemAlbum 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING id[];
        STRING name[];
        NextItemAlbumArtist artist;
    };

     class NextItemTrack 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING id[];
        STRING name[];
        NextItemArtist artist;
        NextItemAlbum album;
        STRING imageUrl[];
        SIGNED_LONG_INTEGER durationMillis;
    };

     class NextItem 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING id[];
        Track track;
    };

     class MetadataRootObject 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        Container container;
        CurrentItem currentItem;
        NextItem nextItem;
        STRING streamInfo[];
    };

    static class Logger 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION PrintLine ( STRING line );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class XMLStructures 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class Envelope 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Body[];
    };

     class Body 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        BrowseReponse browseResponse;
    };

     class BrowseReponse 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Result[];
        STRING NumberReturned[];
        STRING TotalMatches[];
        STRING UpdateID[];
    };

     class GroupCoordinatorChangeMessageStructure 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GroupCoordinatorChangeMessageRootObject 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING groupStatus[];
        STRING groupName[];
        STRING websocketUrl[];
        STRING playerId[];
    };

    static class SystemManager 
    {
        // class delegates

        // class events

        // class functions
        static STRING_FUNCTION GetFirstStaticGroupName ();
        static FUNCTION ClearDynamicGroups ();
        static FUNCTION ClearSonosGroups ();
        static FUNCTION UngroupAllSonosZones ();
        static FUNCTION PrintGroupStuctures ();
        static FUNCTION DiscoverGroups ();
        static FUNCTION GetFavorites ();
        static FUNCTION EvaluateSystemConnection ();
        static SIGNED_LONG_INTEGER_FUNCTION GetServerPort ();
        static FUNCTION TriggerSystemDriverInitializationCompleteEvent ( SystemDriver result );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static SystemDriver SystemDriverInstance;
        static STRING ControllerIpAddress[];

        // class properties
    };

     class SystemStorageStructures 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class DeviceControl 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        DeviceDriver deviceDriverInstance;

        // class properties
    };

     class browseRequest 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING command[];

        // class properties
    };

     class SonosItem 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SonosTrack Track;
        SonosDIDL DIDL;
    };

     class MenuClass 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING MenuTitle[];
        STRING MenuSubtitle[];
        SIGNED_LONG_INTEGER MenuID;
        STRING Searchable[];
        STRING Editable[];
        STRING PlayAll[];

        // class properties
    };

     class TextLinesClass 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING NowPlayingL1[];
        STRING NowPlayingL2[];
        STRING NowPlayingL3[];
        STRING NowPlayingL4[];
        STRING NowPlayingL5[];
        SIGNED_LONG_INTEGER TrackLength;
        STRING L1[];
        STRING L2[];
        STRING icon[];
        SIGNED_LONG_INTEGER GoToMenuID;
        SIGNED_LONG_INTEGER PopUpID;
        eTrackType Type;

        // class properties
    };

     class MediaPlayerClass 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        SIGNED_LONG_INTEGER IDofRootMenu;
        SIGNED_LONG_INTEGER IDofQuickMenu;

        // class properties
    };

     class DeviceMediaPlayer 
    {
        // class delegates
        delegate FUNCTION DelegateFn ( );
        delegate FUNCTION DelegateFnString ( SIMPLSHARPSTRING myString );

        // class events
        EventHandler BusyEvent ( DeviceMediaPlayer sender, BusyEventArgs e );
        EventHandler ClearBusyEvent ( DeviceMediaPlayer sender, ClearBusyEventArgs e );

        // class functions
        FUNCTION SetDefaultPlayerName ( STRING paramName );
        FUNCTION ReturnedBrowseList ( UIBrowseList returnedMenu );
        FUNCTION ReturnedBrowseListContainer ( UIBrowseList returnedMenu );
        FUNCTION GetGroupInfo ();
        FUNCTION GetFavoriteInfo ();
        FUNCTION GetPlaybackStatus ();
        FUNCTION GetPlaybackMetadata ();
        FUNCTION GetVolumeInfo ();
        FUNCTION GetPlaybackError ();
        FUNCTION SubscribeToEvents ();
        FUNCTION UnsubscribeToEvents ();
        FUNCTION TriggerBusyEvent ( STRING result );
        FUNCTION TriggerClearBusyEvent ( STRING result );
        FUNCTION SetPlayer ( SIGNED_LONG_INTEGER grouptoselect );
        FUNCTION SetPlayerByName ( STRING playertoselect );
        FUNCTION PlayFavorite ( SIGNED_LONG_INTEGER favoriteselected );
        FUNCTION PlayFavoriteByName ( STRING favoritetoselect );
        FUNCTION UiPlay ();
        FUNCTION UiPause ();
        FUNCTION UiNextTrack ();
        FUNCTION UiPreviousTrack ();
        FUNCTION VolumeUp ();
        FUNCTION VolumeDown ();
        FUNCTION SetVolumeLevel ( INTEGER volumelevel );
        FUNCTION Mute ();
        FUNCTION Unmute ();
        FUNCTION MediaPlayerConstructor ();
        FUNCTION InitializeMP ( INTEGER port , INTEGER adapterID , SIGNED_LONG_INTEGER connectionType );
        FUNCTION myTransport_Sendback ( STRING stream );
        FUNCTION MessageIn ( STRING pkt );
        FUNCTION SetStateChangedEventforAllProperties ();
        FUNCTION TriggerStateChangedEvent ();
        FUNCTION TriggerStatusMsgEvent ( STRING text , SIGNED_LONG_INTEGER timeoutSec , STRING userInputRequired , SIGNED_LONG_INTEGER show );
        FUNCTION TimerStart ();
        FUNCTION TimerPause ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        SystemDriver SystemDriverInstance;
        DeviceDriver DeviceInstance;
        SonosItem FavoriteInstance;
        STRING ListOfGroupNames[][];
        INTEGER NumberOfGroups;
        STRING ListOfFavorites[][];
        STRING ListOfFavoritesDescriptions[][];
        STRING ListOfFavoritesImageURLs[][];
        INTEGER NumberOfFavorites;
        SIGNED_LONG_INTEGER SelectedGroup;
        STRING GroupName[];
        STRING GroupId[];
        STRING HouseholdId[];
        STRING WebsocketUrl[];
        SIGNED_LONG_INTEGER SelectedFavorite;
        STRING FavoriteName[];
        STRING FavoriteDescription[];
        STRING FavoriteImageURL[];
        STRING BusyStatus[];
        STRING DiscoveringGroups[];
        STRING GettingFavorites[];
        STRING SystemDriverComplete[];
        STRING IsPlaying[];
        STRING IsPaused[];
        STRING IsBuffering[];
        STRING IsIdle[];
        STRING NextTrackAvailable[];
        STRING PreviousTrackAvailable[];
        STRING ShowTrackProgress[];
        STRING SeekingAvailable[];
        STRING IsMuted[];
        STRING VolumeIsFixed[];
        STRING RepeatSupported[];
        STRING RepeatEnabled[];
        STRING RepeatOneSupported[];
        STRING RepeatOneEnabled[];
        STRING ShuffleSupported[];
        STRING ShuffleEnabled[];
        STRING CrossfadeSupported[];
        STRING CrossfadeEnabled[];
        INTEGER VolumeLevel;
        SIGNED_LONG_INTEGER NowPlayingTrackLengthMilliseconds;
        SIGNED_LONG_INTEGER NowPlayingTrackPositionMilliseconds;
        INTEGER NowPlayingTrackLengthSeconds;
        INTEGER NowPlayingTrackPositionSeconds;
        INTEGER NowPlayingTrackPositionGauge;
        STRING PlaybackState[];
        STRING PlaybackError[];
        STRING NowPlayingContainerName[];
        STRING NowPlayingProviderName[];
        STRING NowPlayingTrackName[];
        STRING NowPlayingArtist[];
        STRING NowPlayingAlbum[];
        STRING NowPlayingTrackNumber[];
        STRING NowPlayingGenre[];
        STRING NowPlayingImageURL[];
        STRING NowPlayingTrackLengthString[];
        STRING NowPlayingTrackPositionString[];
        MediaPlayerClass Data;
        STRING Name[];
        STRING UnusedMenu[];
        SIGNED_LONG_INTEGER CurrentNowPlayingMenu;
        SIGNED_LONG_INTEGER CurrentNowPlayingItem;

        // class properties
        DelegateProperty DelegateFn PlayerConnectionUpdate;
        DelegateProperty DelegateFn PlayerBusyUpdate;
        DelegateProperty DelegateFn BrowseListBusyUpdate;
        DelegateProperty DelegateFn DirectSourcesListUpdate;
        DelegateProperty DelegateFn GroupsListUpdate;
        DelegateProperty DelegateFn FavoritesListUpdate;
        DelegateProperty DelegateFn PlayersAndGroupsListUpdate;
        DelegateProperty DelegateFn PlayersListUpdate;
        DelegateProperty DelegateFn MusicSourcesListUpdate;
        DelegateProperty DelegateFn PlayerInfoUpdate;
        DelegateProperty DelegateFn FavoriteInfoUpdate;
        DelegateProperty DelegateFn PlayerStateUpdate;
        DelegateProperty DelegateFn PlayerNowPlayingInfoUpdate;
        DelegateProperty DelegateFn PlayerNowPlayingProgressUpdate;
        DelegateProperty DelegateFn PlayerVolumeUpdate;
        DelegateProperty DelegateFn PlayerPlaybackErrorUpdate;
        DelegateProperty DelegateFn BrowseListUpdate;
        STRING DefaultPlayerName[];
        STRING OfflineState[];
        DelegateProperty DelegateFnString MessageOut;
        SIGNED_LONG_INTEGER Version;
        SIGNED_LONG_INTEGER Instance;
        STRING Language[];
        STRING ActionsSupported[][];
        STRING ActionsAvailable[][];
        STRING PropertiesSupported[][];
        STRING LaunchURI[];
        STRING LaunchIconURL[];
        SIGNED_LONG_INTEGER RewindSpeed;
        SIGNED_LONG_INTEGER FfwdSpeed;
        STRING ProviderName[];
        STRING PlayerState[];
        SIGNED_LONG_INTEGER PlayerIcon;
        STRING PlayerIconURL[];
        STRING PlayerName[];
        STRING StreamState[];
        STRING MediaType[];
        STRING Title[];
        STRING Artist[];
        STRING Album[];
        STRING Genre[];
        STRING Composer[];
        STRING AlbumArtUrl[];
        STRING StationName[];
        SIGNED_LONG_INTEGER ElapsedSec;
        SIGNED_LONG_INTEGER TrackSec;
        SIGNED_LONG_INTEGER TrackNum;
        SIGNED_LONG_INTEGER TrackCnt;
        STRING NextTitle[];
        SIGNED_LONG_INTEGER MaxPresets;
        STRING PresetNames[][];
        SIGNED_LONG_INTEGER ShuffleState;
        SIGNED_LONG_INTEGER RepeatState;
        STRING TextLines[][];
        STRING Band[][];
    };

     class DeviceMediaMenu 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION InitializeMenu ( DeviceMediaPlayer MP1 , DeviceDriver DD1 );
        FUNCTION SetListUpdateProperties ();
        FUNCTION TriggerStateChangedEvent ();
        FUNCTION TriggerBusyEvent ( SIGNED_LONG_INTEGER state , SIGNED_LONG_INTEGER timeoutval );
        FUNCTION TriggerUpdateEvent ( SIGNED_LONG_INTEGER item , SIGNED_LONG_INTEGER count );
        FUNCTION TriggerClearEvent ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING Name[];
        SIGNED_LONG_INTEGER popUpID;
        SIGNED_LONG_INTEGER currentItem;

        // class properties
        SIGNED_LONG_INTEGER Version;
        STRING Language[];
        SIGNED_LONG_INTEGER Instance;
        SIGNED_LONG_INTEGER TransactionId;
        STRING Title[];
        STRING Subtitle[];
        SIGNED_LONG_INTEGER ItemCnt;
        STRING FindDesired[];
        STRING FindSupported[][];
        SIGNED_LONG_INTEGER Level;
        STRING Sorted[];
        SIGNED_LONG_INTEGER MaxReqItems;
        STRING ListSpecificFunctions[][];
        STRING ActionsAvailable[][];
        STRING ActionsSupported[][];
    };

     class SystemDriverInitializationCompleteEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        SystemDriver status;

        // class properties
    };

     class OfflineStateChangedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ConnectionStateChangedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GroupTopologyStartedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GroupTopologyCompleteEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class DiscoveryStartedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class DiscoveryCompleteEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GettingFavoritesEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class FavoritesCompleteEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class SystemDriverCompleteEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ConnectionCompletedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GroupCoordinatorChangeEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GroupVolumeChangeEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PlaybackMetaDataChangeEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PlaybackErrorEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING error[];

        // class properties
    };

     class PlaybackStatusChangeEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GlobalErrorEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING error[];

        // class properties
    };

     class BusyEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING status[];

        // class properties
    };

     class ClearBusyEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING status[];

        // class properties
    };

     class SonosPlayer 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING PlayerName[];
        STRING UUID[];
        STRING Location[];
        STRING CoordinatorName[];
    };

     class PlaybackStatusMessageStructure 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PlayModes 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class AvailablePlaybackActions 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PlaybackStatusRootObject 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING playbackState[];
        SIGNED_LONG_INTEGER positionMillis;
        STRING queueVersion[];
        STRING itemId[];
        PlayModes playModes;
        AvailablePlaybackActions availablePlaybackActions;
    };

namespace SonosProLibrary_v2_3;
        // class declarations
         class WebSocketConnectionImpl;
         class DeviceDataManagerImpl;
     class WebSocketConnectionImpl 
    {
        // class delegates

        // class events
        EventHandler WebsockectConnectionStateChangedEvent ( WebSocketConnectionImpl sender, ConnectionStateChangedEventArgs e );

        // class functions
        FUNCTION DisconnectWebsocket ();
        FUNCTION Connect ( STRING url );
        FUNCTION Send ( STRING message );
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupName[];
    };

     class DeviceDataManagerImpl 
    {
        // class delegates

        // class events
        EventHandler OnTimeoutErrorEvent ( DeviceDataManagerImpl sender, EventArgs e );

        // class functions
        FUNCTION ClearCommandQueue ();
        FUNCTION HandleOutgoingMessage ( MessageRequestStructure outgoing );
        FUNCTION HandleIncomingMessage ( STRING incoming );
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING RoomName[];
    };

