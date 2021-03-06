# Creating Web Based Music Player System Using MVC and AngularJs
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- ASP.NET Web API
- AngularJS
## Topics
- ASP.NET MVC
- ASP.NET Web API
- AngularJS
## Updated
- 09/29/2016
## Description

<h1>Introduction</h1>
<p><a href="https://www.youtube.com/watch?v=t0yZ_p2eD_M&feature=youtu.be" target="_blank"><img id="159022" src="159022-01.png" alt="" width="466" height="238"></a></p>
<p><span>Click here to see the Vide Tutorial &gt;&nbsp;</span><a href="https://www.youtube.com/watch?v=t0yZ_p2eD_M&feature=youtu.be" target="_blank">Link&nbsp;</a><span>to YouTube video.</span></p>
<p>In this article, we will learn how to create a simple web based music player system using MVC, AngularJS and Web API.</p>
<h1><strong>What is SHANU Music Player?</strong></h1>
<p>SHANU Music Player is a web-based music player system. User can upload their songs and play the selected albums. SHANU Music Player has two modules</p>
<div>1) Play Music</div>
<div>2) Album/Music CRUD (Upload and Manage Songs).</div>
<h2>Music Player:</h2>
<div>This is the main module; users can play their favorite uploaded music from this page. First, by default, we will display the albums with album name and image. User can click on any of their favorite albums to play the music. When user clicks on the album
 image, we will play the first song of that album, by default. Users can add any number of songs to their albums to play.</div>
<p><img id="159023" src="159023-1.gif" alt="" width="551" height="341"></p>
<p><span>After the user selects the album, we will check for the songs to be added in the album. If there are no songs for the selected album, then we display the message as &quot;No Songs has been added in this Album&rdquo;. If album has songs, then we display
 our Shanu Music Player. From this page, the user can change and play any songs from the list as per his/her choice. In the player, we will display the album image and the title along with the current playing song file name. In the list, we will also display
 singer name, music file name, &nbsp;and description of the file. User can play, pause, and play next and previous songs of the list</span></p>
<p><img id="159024" src="159024-2.png" alt="" width="360" height="225"></p>
<h2><strong>Album/Music CRUD (Upload and Manage Songs)</strong></h2>
<p><img id="159025" src="159025-3.png" alt="" width="553" height="346"></p>
<p><span>In this module, we will manage album and music information. User can add albums with images and song details and upload songs in the album.&nbsp;</span></p>
<h3><strong>Manage Album Details</strong></h3>
<p><img id="159026" src="159026-4.png" alt="" width="371" height="141"></p>
<p>&nbsp;</p>
<p><span>Here, user can add album details with image. Albums are nothing but it&rsquo;s a favorite or play list. First, user can create albums and add all his/her favorite songs in that album. In the database, we have created two tables. One is Album table
 (as master) and another is music table (as details).</span></p>
<h3><strong>Music CRUD</strong></h3>
<p><img id="159027" src="159027-5.png" alt="" width="527" height="288"></p>
<p><span>This is our main part as we will be adding all our music files to be played in this detail table. Here, we select our album from combobox and add music details and upload to our root directory to play our songs. Users can add new songs, edit, and delete
 the songs. We will see more detail in code part.</span></p>
<h1><span>Building the Sample</span></h1>
<p><br>
<strong>Prerequisites</strong></p>
<ul>
<li>Visual Studio 2015: You can download it from&nbsp;<a href="https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx" target="_blank">here</a>.
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h1><strong>Create Database and Table</strong></h1>
<p><span>The following is the script to create a database, table, and sample insert query. Run this script in your SQL Server. I have used SQL Server 2014.&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Author&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Create&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-02</span><span class="js__num">-28</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Description&nbsp;:&nbsp;To&nbsp;Create&nbsp;Database&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
--Script&nbsp;to&nbsp;create&nbsp;DB,Table&nbsp;and&nbsp;sample&nbsp;Insert&nbsp;data&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
USE&nbsp;MASTER;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">1</span>)&nbsp;Check&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;<span class="js__operator">new</span>&nbsp;DB&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.databases&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'musicPlayerDB'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;musicPlayerDB&nbsp;SET&nbsp;SINGLE_USER&nbsp;WITH&nbsp;ROLLBACK&nbsp;IMMEDIATE&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;DATABASE&nbsp;musicPlayerDB&nbsp;;&nbsp;&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
CREATE&nbsp;DATABASE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(&nbsp;SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.tables&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'AlbumMaster'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;TABLE&nbsp;AlbumMaster&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;AlbumMaster&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
AlbumID&nbsp;int&nbsp;identity(<span class="js__num">1</span>,<span class="js__num">1</span>),&nbsp;&nbsp;&nbsp;&nbsp;
AlbumName&nbsp;VARCHAR(<span class="js__num">200</span>)&nbsp;NOT&nbsp;NULL&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;
ImageName&nbsp;VARCHAR(<span class="js__num">500</span>)&nbsp;NOT&nbsp;NULL&nbsp;&nbsp;&nbsp;&nbsp;
CONSTRAINT&nbsp;[PK_AlbumMaster]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
[AlbumID]&nbsp;ASC&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
Insert&nbsp;into&nbsp;AlbumMaster(AlbumName,ImageName)&nbsp;Values(<span class="js__string">'RedAlbum'</span>,<span class="js__string">'RedAlbum.jpg'</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
select&nbsp;*&nbsp;from&nbsp;AlbumMaster&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(&nbsp;SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.tables&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'MusicPlayerMaster'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;TABLE&nbsp;MusicPlayerMaster&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;MusicPlayerMaster&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
MusicID&nbsp;int&nbsp;identity(<span class="js__num">1</span>,<span class="js__num">1</span>),&nbsp;&nbsp;&nbsp;&nbsp;
SingerName&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;
AlbumName&nbsp;VARCHAR(<span class="js__num">200</span>)&nbsp;NOT&nbsp;NULL&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;
MusicFileName&nbsp;VARCHAR(<span class="js__num">500</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;
Description&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;NOT&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
CONSTRAINT&nbsp;[PK_MusicPlayerMaster]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
[MusicID]&nbsp;ASC&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
select&nbsp;*&nbsp;from&nbsp;MusicPlayerMaster&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Stored Procedure :</strong><span>&nbsp;Run all this procedure one by one in your SQL Server,</span></p>
<p><span>&nbsp;</span><strong>SP to select all records of Album Details</strong></p>
<p>&nbsp;</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;To&nbsp;Select&nbsp;Albumdetails&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;EXEC&nbsp;USP_AlbumMaster_Select&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[USP_AlbumMaster_Select]&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
@AlbumName&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;=&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;
AS&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
SELECT&nbsp;AlbumID,AlbumName&nbsp;,&nbsp;ImageName&nbsp;&nbsp;&nbsp;
FROM&nbsp;AlbumMaster&nbsp;&nbsp;&nbsp;&nbsp;
WHERE&nbsp;&nbsp;&nbsp;&nbsp;
AlbumName&nbsp;like&nbsp;@AlbumName&nbsp;&#43;<span class="js__string">'%'</span>&nbsp;&nbsp;&nbsp;&nbsp;
Order&nbsp;By&nbsp;AlbumName&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>&nbsp;SP to Insert Album Details.</strong></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;To&nbsp;insert&nbsp;&nbsp;&nbsp;
--&nbsp;EXEC&nbsp;[USP_Album_Insert]&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[USP_Album_Insert]&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
@AlbumName&nbsp;VARCHAR(<span class="js__num">200</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@ImageName&nbsp;VARCHAR(<span class="js__num">500</span>)&nbsp;=&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;
AS&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;NOT&nbsp;EXISTS&nbsp;(SELECT&nbsp;*&nbsp;FROM&nbsp;AlbumMaster&nbsp;WHERE&nbsp;AlbumName=@AlbumName)&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].AlbumMaster&nbsp;(AlbumName&nbsp;,ImageName&nbsp;)&nbsp;&nbsp;&nbsp;
VALUES&nbsp;(@AlbumName&nbsp;,@ImageName&nbsp;)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
Select&nbsp;<span class="js__string">'Inserted'</span>&nbsp;as&nbsp;results&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;&nbsp;
ELSE&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
Select&nbsp;<span class="js__string">'Exists'</span>&nbsp;as&nbsp;results&nbsp;&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<strong>SP to select all records of Music details</strong></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">1</span>)&nbsp;select&nbsp;all&nbsp;MusicPlayerMaster&nbsp;records&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;Author&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Create&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-08</span><span class="js__num">-23</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Description&nbsp;:select&nbsp;top&nbsp;<span class="js__num">10</span>&nbsp;random&nbsp;kidsLearnerMaster&nbsp;records&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Tables&nbsp;used&nbsp;:&nbsp;MusicPlayerMaster&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modifier&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-08</span><span class="js__num">-23</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;To&nbsp;Select&nbsp;all&nbsp;user&nbsp;roles&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;EXEC&nbsp;USP_MusicAlbum_SelectALL&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[USP_MusicAlbum_SelectALL]&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
@AlbumName&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;=&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;
AS&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
SELECT&nbsp;MusicID,&nbsp;&nbsp;&nbsp;&nbsp;
SingerName&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;
AlbumName&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;
MusicFileName,&nbsp;&nbsp;&nbsp;&nbsp;
Description&nbsp;&nbsp;&nbsp;&nbsp;
FROM&nbsp;MusicPlayerMaster&nbsp;&nbsp;&nbsp;&nbsp;
WHERE&nbsp;&nbsp;&nbsp;&nbsp;
AlbumName&nbsp;like&nbsp;@AlbumName&nbsp;&#43;<span class="js__string">'%'</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>&nbsp;SP to Insert Music Details</strong></div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
Insert&nbsp;MusicPlayerMaster&nbsp;records&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;Author&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Create&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-08</span><span class="js__num">-23</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Description&nbsp;:Insert&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Tables&nbsp;used&nbsp;:&nbsp;MusicPlayerMaster&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modifier&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-08</span><span class="js__num">-23</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;To&nbsp;insert&nbsp;&nbsp;&nbsp;
--&nbsp;EXEC&nbsp;USP_MusicAlbum_Insert&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;PROCEDURE&nbsp;[dbo].[USP_MusicAlbum_Insert]&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
@SingerName&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@AlbumName&nbsp;VARCHAR(<span class="js__num">200</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@MusicFileName&nbsp;VARCHAR(<span class="js__num">500</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@Description&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;=&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;
AS&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;NOT&nbsp;EXISTS&nbsp;(SELECT&nbsp;*&nbsp;FROM&nbsp;MusicPlayerMaster&nbsp;WHERE&nbsp;MusicFileName=@MusicFileName)&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[MusicPlayerMaster]&nbsp;&nbsp;&nbsp;
(SingerName&nbsp;,AlbumName&nbsp;,MusicFileName&nbsp;,Description)&nbsp;&nbsp;&nbsp;
VALUES&nbsp;&nbsp;&nbsp;
(@SingerName&nbsp;,@AlbumName&nbsp;,@MusicFileName&nbsp;,@Description)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
Select&nbsp;<span class="js__string">'Inserted'</span>&nbsp;as&nbsp;results&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;&nbsp;
ELSE&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
Select&nbsp;<span class="js__string">'Exists'</span>&nbsp;as&nbsp;results&nbsp;&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>SP to Update Music Details</strong></div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;
Update&nbsp;all&nbsp;MusicPlayerMaster&nbsp;records&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;Author&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Create&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-08</span><span class="js__num">-23</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Description&nbsp;:Update&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Tables&nbsp;used&nbsp;:&nbsp;MusicPlayerMaster&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modifier&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-08</span><span class="js__num">-23</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;To&nbsp;Select&nbsp;all&nbsp;user&nbsp;roles&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;EXEC&nbsp;USP_MusicAlbum_Update&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;
Create&nbsp;PROCEDURE&nbsp;[dbo].[USP_MusicAlbum_Update]&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;
@musicID&nbsp;VARCHAR(<span class="js__num">20</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@SingerName&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@AlbumName&nbsp;VARCHAR(<span class="js__num">200</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@MusicFileName&nbsp;VARCHAR(<span class="js__num">500</span>)&nbsp;=&nbsp;<span class="js__string">''</span>,&nbsp;&nbsp;&nbsp;&nbsp;
@Description&nbsp;VARCHAR(<span class="js__num">100</span>)&nbsp;=&nbsp;<span class="js__string">''</span>&nbsp;&nbsp;&nbsp;
)&nbsp;&nbsp;&nbsp;&nbsp;
AS&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;
UPDATE&nbsp;[dbo].[MusicPlayerMaster]&nbsp;&nbsp;&nbsp;
SET&nbsp;[SingerName]&nbsp;=&nbsp;@SingerName,&nbsp;&nbsp;&nbsp;
[AlbumName]&nbsp;=&nbsp;@AlbumName,&nbsp;&nbsp;&nbsp;
[MusicFileName]&nbsp;=&nbsp;@MusicFileName,&nbsp;&nbsp;&nbsp;
[Description]&nbsp;=&nbsp;@Description&nbsp;&nbsp;&nbsp;&nbsp;
WHERE&nbsp;&nbsp;&nbsp;&nbsp;
musicID&nbsp;=&nbsp;@musicID&nbsp;&nbsp;&nbsp;&nbsp;
Select&nbsp;<span class="js__string">'Updated'</span>&nbsp;as&nbsp;results&nbsp;&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>&nbsp;SP to Delete record by Admin</strong></div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">&nbsp;USE&nbsp;musicPlayerDB&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">5</span>)&nbsp;Stored&nbsp;procedure&nbsp;To&nbsp;Delete&nbsp;&nbsp;KIDSLEARN&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
--&nbsp;Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Create&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-02</span><span class="js__num">-28</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Description&nbsp;:To&nbsp;Delete&nbsp;KIDSLEARN&nbsp;detail&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Tables&nbsp;used&nbsp;:&nbsp;&nbsp;kidsLearnerMaster&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modifier&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;<span class="js__num">2016</span><span class="js__num">-02</span><span class="js__num">-28</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;To&nbsp;<span class="js__operator">delete</span>&nbsp;KIDSLEARN&nbsp;record&nbsp;&nbsp;&nbsp;
--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Create&nbsp;PROCEDURE&nbsp;[dbo].[USP_KIDSLEARN_Delete]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;(&nbsp;@KIDIDENTITY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VARCHAR(<span class="js__num">20</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="js__string">''</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
AS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
BEGIN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DELETE&nbsp;FROM&nbsp;kidsLearnerMaster&nbsp;WHERE&nbsp;KIDIDENTITY=@KIDIDENTITY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
END&nbsp;&nbsp;</pre>
</div>
</div>
</div>
&nbsp;<strong style="font-size:2em">Create your MVC Web Application in Visual Studio 2015</strong></div>
<div class="endscriptcode"><br>
<span>After installing the Visual Studio 2015, click Start &gt;&gt; Programs &gt;&gt; select Visual Studio 2015 &gt;&gt; Click Visual Studio 2015. Click New &gt;&gt; Project &gt;&gt; select Web &gt;&gt; ASP.NET Web Application. Enter your project name and click
 OK.&nbsp;</span></div>
<div class="endscriptcode"><img id="159029" src="159029-6.png" alt="" width="496" height="245"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>Select MVC,WEB API and click OK.</span></div>
<div class="endscriptcode"><img id="159030" src="159030-7.png" alt="" width="488" height="312"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong>Web.Config : To upload large file size</strong><br>
<br>
<span>Note: Here, we need to upload music files as mp3 or wav. So, we need to upload large files to our root directory. For uploading large files in webconfig, we add the below code part,</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;system</span>.web<span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;httpRuntime</span>&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">executionTimeout</span>=<span class="xml__attr_value">&quot;3600&quot;</span>&nbsp;<span class="xml__attr_name">maxRequestLength</span>=<span class="xml__attr_value">&quot;102400&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;/system.web&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;system</span>.webServer<span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;security</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;requestFiltering</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;requestLimits</span>&nbsp;<span class="xml__attr_name">maxAllowedContentLength</span>=<span class="xml__attr_value">&quot;104857600&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/requestFiltering&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/security&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;/system.webServer&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-size:1.5em">Add Database using ADO.NET Entity Data Model</strong></div>
</div>
<div class="endscriptcode"><br>
<span>Right click the project and click Add, then New Item. Select Data, then ADO.NET Entity Data Model and give the name for your EF and click Add.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="159031" src="159031-8.png" alt="" width="401" height="269"></div>
<div class="endscriptcode"><span>Select &quot;EF Designer from database&quot; and click Next.</span></div>
<div class="endscriptcode"><img id="159032" src="159032-9.png" alt="" width="515" height="327"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>Connect to your database. Click&nbsp;</span><strong>Next</strong><span>&nbsp;to select Tables and Stored Procedure for Menu management.</span></div>
<p><img id="159033" src="159033-10.png" alt="" width="409" height="509"></p>
<p>&nbsp;</p>
<p><span>Now, select all your tables and Stored procedure details and click&nbsp;</span><strong>Finish</strong><span>.</span></p>
<p><img id="159034" src="159034-11.png" alt="" width="524" height="497"></p>
<h1><strong>Adding Web API Controller</strong></h1>
<p>Right-click the Controllers folder. Click Add and then click Controller.<br>
<br>
Select Web API 2 Controller &ndash; Empty, click add and give name for your Web API controller.<br>
<br>
<strong>Working with WEBAPI Controller for CRUD&nbsp;</strong><br>
<br>
Select Controller and add an Empty Web API 2 Controller. Provide your name to the Web API controller and click OK. Here, for our Web API Controller, we have given the name &ldquo;MusicAPIController&quot;.&nbsp;<br>
<br>
As we have created Web API controller, we can see that our controller has been inherited with ApiController. As we all know, Web API is a simple and easy way to build HTTP Services for Browsers and Mobiles.<br>
<br>
Web API has the following four methods as Get/Post/Put and Delete where:</p>
<ul>
<li>Get is to request for the data. (Select) </li><li>Post is to create a data. (Insert) </li><li>Put is to update the data. </li><li>Delete is to delete data. </li></ul>
<p><strong>Get Method</strong><br>
<br>
In our example, I have used only one Get method since I am using only one Stored Procedure. We need to create an object for our Entity and write our Get method to do Select/Insert/Update and Delete operations.&nbsp;<br>
<strong><br>
Select Operation</strong><br>
<br>
We use a Get method to get all the details of the both AlbumMaster and MusicDetail tables using an entity object and we return the result as IEnumerable. We use this method in our AngularJS and display the result in an MVC page from the AngularJS controller.
 Using Ng-Repeat, we can bind the details.<br>
<br>
Here, we can see in the getAlbums method I have passed the search parameter to the USP_AlbumMaster_Select ALL Stored Procedure. In the Stored Procedure, I used like &quot;%&quot; to return all the records if the search parameter is empty.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;select&nbsp;Album&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;USP_AlbumMaster_Select_Result&gt;&nbsp;getAlbums(string&nbsp;AlbumName)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(AlbumName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;objapi.USP_AlbumMaster_Select(AlbumName).AsEnumerable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Insert Operation</strong><br>
<br>
The same as select, we passed all the parameters to the insert procedure. This insert method will return the result from the database as a record is inserted or not. We will get the result and display it from the AngularJS Controller to MVC application.&nbsp;<br>
<div class="dp-highlighter">
<div class="bar"></div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;string&gt;&nbsp;insertAlbum(string&nbsp;AlbumName,&nbsp;string&nbsp;ImageName)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(AlbumName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ImageName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;objapi.USP_Album_Insert(AlbumName,&nbsp;ImageName).AsEnumerable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Same like Album, we will be using the methods for Music Details to perform our CRUD operations here is the code for Select, Insert, Update and Delete.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;to&nbsp;Search&nbsp;all&nbsp;Music&nbsp;Album&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
[HttpGet]&nbsp;&nbsp;&nbsp;
public&nbsp;IEnumerable&lt;USP_MusicAlbum_SelectALL_Result&gt;&nbsp;getMusicSelectALL(string&nbsp;AlbumName)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(AlbumName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;objapi.USP_MusicAlbum_SelectALL(AlbumName).AsEnumerable();&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;To&nbsp;insert&nbsp;Music&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
[HttpGet]&nbsp;&nbsp;&nbsp;
public&nbsp;IEnumerable&lt;string&gt;&nbsp;insertMusic(string&nbsp;SingerName,&nbsp;string&nbsp;AlbumName,&nbsp;string&nbsp;MusicFileName,&nbsp;string&nbsp;Description)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(SingerName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SingerName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(MusicFileName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MusicFileName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(AlbumName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Description&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Description&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;objapi.USP_MusicAlbum_Insert(SingerName,&nbsp;AlbumName,&nbsp;MusicFileName,&nbsp;Description).AsEnumerable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;To&nbsp;Update&nbsp;Music&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
[HttpGet]&nbsp;&nbsp;&nbsp;
public&nbsp;IEnumerable&lt;string&gt;&nbsp;updateMusic(string&nbsp;musicID,&nbsp;string&nbsp;SingerName,&nbsp;string&nbsp;AlbumName,&nbsp;string&nbsp;MusicFileName,&nbsp;string&nbsp;Description)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(musicID&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;musicID&nbsp;=&nbsp;<span class="js__string">&quot;0&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(SingerName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SingerName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(MusicFileName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MusicFileName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(AlbumName&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Description&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Description&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;objapi.USP_MusicAlbum_Update(musicID,&nbsp;SingerName,&nbsp;AlbumName,&nbsp;MusicFileName,&nbsp;Description).AsEnumerable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;To&nbsp;Delete&nbsp;Music&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
[HttpGet]&nbsp;&nbsp;&nbsp;
public&nbsp;IEnumerable&lt;string&gt;&nbsp;deleteMusic(string&nbsp;musicID)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(musicID&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;musicID&nbsp;=&nbsp;<span class="js__string">&quot;0&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;objapi.USP_MusicAlbum_Delete(musicID).AsEnumerable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span>Next, we will create our AngularJs Controller and View page to perform our CRUD operations to manage both Albums and MusicDetails.</span></p>
<h1><strong>Album/Music CRUD (Upload and Manage Songs)</strong></h1>
<p><img id="159025" src="159025-3.png" alt="" width="553" height="346"></p>
<p>&nbsp;</p>
<h2><strong>Creating AngularJS Controller&nbsp;</strong></h2>
<p><span>Firstly, create a folder inside the Scripts folder and name it as &ldquo;MyAngular&rdquo;.</span></p>
<p><img id="159035" src="159035-12.png" alt="" width="208" height="212"></p>
<p><span>Now, add your Angular Controller inside the folder.&nbsp;</span><br>
<br>
<span>Right click the MyAngular folder and click Add and New Item. Select Web and then AngularJS Controller and provide a name for the Controller. I have named my AngularJS Controller &ldquo;Controller.js&rdquo;.</span></p>
<p><img id="159036" src="159036-13.png" alt="" width="483" height="318"></p>
<p><span>Once the AngularJS Controller is created, we can see by default the controller will have the code with the default module definition and all.&nbsp;</span><br>
<br>
<span>If the AngularJS package is missing, then add the package to your project.&nbsp;Right click your MVC project and click Manage NuGet Packages. Search for AngularJS and click Install.</span></p>
<p><img id="159037" src="159037-14.png" alt="" width="419" height="304"></p>
<h2><strong>&nbsp;Create AngularJS Script Files&nbsp;</strong></h2>
<p><strong>Modules.js:</strong><span>&nbsp;Here, we will add the reference to the AngularJS JavaScript and create an Angular Module named &ldquo;AngularJs_Module&rdquo;.&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;&lt;reference&nbsp;path=&quot;../angular.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="js__statement">var</span>&nbsp;app;&nbsp;&nbsp;&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">&quot;AngularJs_Module&quot;</span>,&nbsp;[<span class="js__string">'ngAnimate'</span>]);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>)();&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Controllers:</strong><span>&nbsp;In AngularJS Controller, I have done all the business logic and returned the data from Web API to our MVC HTML page.&nbsp;</span></p>
<ol>
<li><strong>Variable declarations</strong><br>
<br>
Firstly, we declared all the local variables needed to be used.&nbsp; </li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">app.controller(<span class="js__string">&quot;AngularJs_Controller&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;$timeout,&nbsp;$rootScope,&nbsp;$window,&nbsp;$http&nbsp;,&nbsp;FileUploadService)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.date&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MyName&nbsp;=&nbsp;<span class="js__string">&quot;shanu&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Album&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumIdentitys&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.UImage&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Music&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.musicID&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.SingerName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumNameS&nbsp;=&nbsp;<span class="js__string">&quot;RedAlbum&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicFileName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.Description&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Visible&nbsp;design&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showMusicsAdd&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showAlbum&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showMusics&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showEditMusics&nbsp;=&nbsp;false;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Methods<br>
<br>
<em>Select Method&nbsp;</em></strong><br>
<br>
<span>In the select method, we have used $http.get to get the details of both Album and Music Details from Web API. In the get method, we will provide our API Controller name and method to get the details.&nbsp;</span><br>
<br>
<span>The final result will be displayed to the MVC HTML page using data-ng-repeat.&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;This&nbsp;method&nbsp;is&nbsp;to&nbsp;get&nbsp;all&nbsp;the&nbsp;kids&nbsp;Learn&nbsp;Details&nbsp;to&nbsp;display&nbsp;for&nbsp;CRUD.&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selectAlbumDetails($scope.AlbumName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;selectAlbumDetails(AlbumName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/getAlbums/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;AlbumName:&nbsp;AlbumName&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumData&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.AlbumData.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/getMusicSelectALL/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;AlbumName:&nbsp;AlbumName&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicData&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.AlbumData.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Insert Album&nbsp;</strong><br>
<br>
<span>For adding album, we also upload album image to our rood directory .</span><br>
<br>
<strong><span style="text-decoration:underline">Note:</span></strong><span>&nbsp;First, create a folder named &ldquo;uploads&rdquo; from your solution to upload all your album images and music files like mp3.</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="159039" src="159039-15.png" alt="" width="180" height="209"></p>
<p><strong>Image Upload:</strong><br>
<br>
<strong>$scope.ChechFileValid</strong><br>
<br>
<span>This method checks if the attached image file is valid or not. If the image file is not valid, then display the error message.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$scope.SaveAlbum&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;In this method, pass the image file to the UploadFile method and once the image is uploaded successfully to our root folder, the Album details will be inserted into database.</div>
<p><br>
<span>fac.UploadFile = function (file) In this method, using $http.post, we pass our image file to the MVC Controller and our HTTPost method as in the following,</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Form&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.$watch(<span class="js__string">&quot;f1.$valid&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(isValid)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFormValid&nbsp;=&nbsp;isValid;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//File&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ChechFileValid&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;isValid&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.SelectedFileForUpload&nbsp;!=&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;((file.type&nbsp;==&nbsp;<span class="js__string">'image/png'</span>&nbsp;||&nbsp;file.type&nbsp;==&nbsp;<span class="js__string">'image/jpeg'</span>&nbsp;||&nbsp;file.type&nbsp;==&nbsp;<span class="js__string">'image/gif'</span>)&nbsp;&amp;&amp;&nbsp;file.size&nbsp;&lt;=&nbsp;(<span class="js__num">800</span>&nbsp;*&nbsp;<span class="js__num">800</span>))&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.FileInvalidMessage&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isValid&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.FileInvalidMessage&nbsp;=&nbsp;<span class="js__string">&quot;Only&nbsp;JPEG/PNG/Gif&nbsp;Image&nbsp;can&nbsp;be&nbsp;upload&nbsp;)&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.FileInvalidMessage&nbsp;=&nbsp;<span class="js__string">&quot;Image&nbsp;required!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFileValid&nbsp;=&nbsp;isValid;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//File&nbsp;Select&nbsp;event&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectFileforUpload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;files&nbsp;=&nbsp;file[<span class="js__num">0</span>];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Imagename&nbsp;=&nbsp;files.name;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;alert($scope.Imagename);&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.SelectedFileForUpload&nbsp;=&nbsp;file[<span class="js__num">0</span>];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Save&nbsp;Album&nbsp;File&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.saveAlbum&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFormSubmitted&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Message&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ChechFileValid($scope.SelectedFileForUpload);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.IsFormValid&nbsp;&amp;&amp;&nbsp;$scope.IsFileValid)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileUploadService.UploadFile($scope.SelectedFileForUpload).then(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/insertAlbum/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;AlbumName:&nbsp;$scope.AlbumName,&nbsp;ImageName:&nbsp;$scope.Imagename&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.menuInserted&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert($scope.menuInserted);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cleardetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selectAlbumDetails(<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(e);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Message&nbsp;=&nbsp;<span class="js__string">&quot;All&nbsp;the&nbsp;fields&nbsp;are&nbsp;required.&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
.factory(<span class="js__string">'FileUploadService'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($http,&nbsp;$q)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fac&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fac.UploadFile&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;formData&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FormData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;formData.append(<span class="js__string">&quot;file&quot;</span>,&nbsp;file);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;defer&nbsp;=&nbsp;$q.defer();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.post(<span class="js__string">&quot;/KidslearnAdmin/UploadFile&quot;</span>,&nbsp;formData,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;withCredentials:&nbsp;true,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">'Content-Type'</span>:&nbsp;<span class="js__property">undefined</span>&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;transformRequest:&nbsp;angular.identity&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.success(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defer.resolve(d);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defer.reject(<span class="js__string">&quot;File&nbsp;Upload&nbsp;Failed!&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;defer.promise;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;fac;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//---------------------------------------------&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//End&nbsp;of&nbsp;Image&nbsp;Upload&nbsp;and&nbsp;Insert&nbsp;record&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>This save part explains about our Album details save to our database using AngularJS Controller. Same like this, we will be saving and uploading our music files to our root directory to play our music.</span><br>
<br>
<span>Here is the AngularJS Controller code part to perform our Music Details CRUD operation and upload Music files to our root folder.</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;********&nbsp;&nbsp;&nbsp;Music&nbsp;CRUD&nbsp;Management&nbsp;and&nbsp;MP3&nbsp;File&nbsp;Upload&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Form&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.$watch(<span class="js__string">&quot;f2.$valid&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(isValid)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFormValid&nbsp;=&nbsp;isValid;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;THIS&nbsp;IS&nbsp;REQUIRED&nbsp;AS&nbsp;File&nbsp;Control&nbsp;is&nbsp;not&nbsp;supported&nbsp;2&nbsp;way&nbsp;binding&nbsp;features&nbsp;of&nbsp;Angular&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;------------------------------------------------------------------------------------&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//File&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ChechMusicFileValid&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;isValid&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.selectmp3FileforUpload&nbsp;!=&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.FileInvalidMessage&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isValid&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.FileInvalidMessage&nbsp;=&nbsp;<span class="js__string">&quot;Music&nbsp;File&nbsp;required!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFileValid&nbsp;=&nbsp;isValid;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//to&nbsp;upload&nbsp;Music&nbsp;File&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//File&nbsp;Select&nbsp;event&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectmp3FileforUpload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;files&nbsp;=&nbsp;file[<span class="js__num">0</span>];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicFileName&nbsp;=&nbsp;files.name;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;alert($scope.Imagename);&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectmp3FileforUpload&nbsp;=&nbsp;file[<span class="js__num">0</span>];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Save&nbsp;Music&nbsp;&nbsp;File&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.saveMusicDetails&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFormSubmitted&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Message&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ChechMusicFileValid($scope.selectmp3FileforUpload);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.IsFormValid&nbsp;&amp;&amp;&nbsp;$scope.IsFileValid)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileUploadService.UploadFile($scope.selectmp3FileforUpload).then(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//if&nbsp;the&nbsp;Music&nbsp;ID=0&nbsp;means&nbsp;its&nbsp;new&nbsp;Music&nbsp;insert&nbsp;here&nbsp;i&nbsp;will&nbsp;call&nbsp;the&nbsp;Web&nbsp;api&nbsp;insert&nbsp;method&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.musicID&nbsp;==&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/insertMusic/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;SingerName:&nbsp;$scope.SingerName,&nbsp;AlbumName:&nbsp;$scope.AlbumNameS,&nbsp;MusicFileName:&nbsp;$scope.MusicFileName,&nbsp;Description:&nbsp;$scope.Description&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.menuInserted&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert($scope.menuInserted);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cleardetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selectAlbumDetails(<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;to&nbsp;update&nbsp;to&nbsp;the&nbsp;Music&nbsp;details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/updateMusic/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;musicID:&nbsp;$scope.musicID,&nbsp;SingerName:&nbsp;$scope.SingerName,&nbsp;AlbumName:&nbsp;$scope.AlbumNameS,&nbsp;MusicFileName:&nbsp;$scope.MusicFileName,&nbsp;Description:&nbsp;$scope.Description&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.menuUpdated&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert($scope.menuUpdated);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cleardetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selectAlbumDetails(<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(e);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Message&nbsp;=&nbsp;<span class="js__string">&quot;All&nbsp;the&nbsp;fields&nbsp;are&nbsp;required.&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Edit&nbsp;MusicEdit&nbsp;&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicEdit&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;KidsEdit(musicID,&nbsp;SingerName,&nbsp;AlbumName,&nbsp;MusicFileName,&nbsp;Description)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cleardetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.showEditMusics&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(musicID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.musicID&nbsp;=&nbsp;musicID;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.SingerName&nbsp;=&nbsp;SingerName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumNameS&nbsp;=&nbsp;AlbumName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicFileName&nbsp;=&nbsp;MusicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Description&nbsp;=&nbsp;Description;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Delete&nbsp;MusicDelete&nbsp;Detail&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicDelete&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;KidsDelete(musicIDs)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cleardetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.showEditMusics&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.musicID&nbsp;=&nbsp;musicIDs;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;delConfirm&nbsp;=&nbsp;confirm(<span class="js__string">&quot;Are&nbsp;you&nbsp;sure&nbsp;you&nbsp;want&nbsp;to&nbsp;delete&nbsp;the&nbsp;Kids&nbsp;Lear&nbsp;Detail&nbsp;?&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(delConfirm&nbsp;==&nbsp;true)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/deleteMusic/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;musicID:&nbsp;$scope.musicID&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Music&nbsp;Detail&nbsp;Deleted&nbsp;Successfully!!&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cleardetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selectAlbumDetails(<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;<strong>Music Player Module</strong></h1>
<div class="endscriptcode"><span>This is our main module where user can play his/her favorite songs from this page. First, we will display all Album details with images in home page.&nbsp;</span></div>
<p><img id="159041" src="159041-16.png" alt="" width="531" height="373"></p>
<p>&nbsp;</p>
<p><span>Here, we have created one more AngularJS Controller and named it as HomeController. In this controller, we will get details of albums and music to play our songs.</span><br>
<br>
<strong>Album display:</strong><span>&nbsp;First, we create a new AngularJS controller and declare all variables. In home page, we display all the album details with image and album title. By default, we call the selectAlbumDetails() method to display the album
 details in home page.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;&lt;reference&nbsp;path=&quot;../angular.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;app;&nbsp;&nbsp;&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">&quot;AngularJsHome_Module&quot;</span>,&nbsp;[<span class="js__string">'ngAnimate'</span>]);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>)();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
app.controller(<span class="js__string">&quot;AngularJsHome_Controller&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;$timeout,&nbsp;$rootScope,&nbsp;$window,&nbsp;$http)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.date&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MyName&nbsp;=&nbsp;<span class="js__string">&quot;shanu&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Album&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumIdentitys&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumImage&nbsp;=&nbsp;<span class="js__string">&quot;RedAlbum.jpg&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumName&nbsp;=&nbsp;<span class="js__string">&quot;RedAlbu&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Music&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.musicID&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.SingerName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumNameS&nbsp;=&nbsp;<span class="js__string">&quot;RedAlbum&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicFileName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.Description&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Play&nbsp;Songs&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.songsCount&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.CurrentSong&nbsp;=&nbsp;<span class="js__string">&quot;Alarm06NOK.wav&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongstoPlay&nbsp;=&nbsp;<span class="js__string">&quot;/uploads/Alarm06NOK.wav&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Visible&nbsp;design&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showAlbum&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showMusics&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showButton&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showSounds&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;method&nbsp;is&nbsp;to&nbsp;get&nbsp;all&nbsp;the&nbsp;kids&nbsp;Learn&nbsp;Details&nbsp;to&nbsp;display&nbsp;for&nbsp;CRUD.&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selectAlbumDetails(<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;selectAlbumDetails(AlbumName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/getAlbums/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;AlbumName:&nbsp;AlbumName&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumData&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.AlbumData.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>In home page, we display only 3 Album details in one row. To fix the 3 columns, &nbsp;first in home page Index View page, we add this CSS style.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>

<div class="preview">
<pre class="js">.columns&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;columns:&nbsp;<span class="js__num">3</span>;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>In html part, we use this style in div tag to display 3 columns per row.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;class=<span class="js__string">&quot;columns&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;ng-repeat=<span class="js__string">&quot;details&nbsp;in&nbsp;AlbumData&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;style=<span class="js__string">'width:&nbsp;99%;table-layout:fixed;'</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;src=<span class="js__string">&quot;~/uploads/{{details.ImageName}}&quot;</span>&nbsp;alt=<span class="js__string">&quot;{{details.ImageName}}&quot;</span>&nbsp;width=<span class="js__string">&quot;144px&quot;</span>&nbsp;height=<span class="js__string">&quot;144px&quot;</span>&nbsp;ng-click=<span class="js__string">&quot;showMusicAlbum(details.AlbumName,&nbsp;details.ImageName)&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#257815;font-size:large&quot;</span>&gt;&lt;b&gt;<span class="js__brace">{</span><span class="js__brace">{</span>details.AlbumName<span class="js__brace">}</span><span class="js__brace">}</span>&lt;<span class="js__reg_exp">/b&gt;&lt;/</span>span&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;src=<span class="js__string">&quot;~/Images/blank.gif&quot;</span>&nbsp;alt=<span class="js__string">&quot;&quot;</span>&nbsp;width=<span class="js__string">&quot;1&quot;</span>&nbsp;height=<span class="js__string">&quot;2&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Music Player</strong></div>
<p><img id="159042" src="159042-17.png" alt="" width="424" height="306"></p>
<p>&nbsp;</p>
<h2><strong>To Play Songs</strong></h2>
<p><span>In Music player part, first we declare the audio tag in html part .In audio tag, we give the source audio file from our AngularJS controller part.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;audio&nbsp;id=<span class="js__string">&quot;audioPlay&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;source&nbsp;&nbsp;src=<span class="js__string">&quot;{{selectedSongstoPlay}}&quot;</span>&gt;&lt;/source&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/audio&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>To Play Songs<br>
</strong><br>
<span>To play the songs, first we will be loading all the songs of the selected album. In this method, we pass our selected Album to our Web API to load all songs. If there is no records for the album, then we display the message as (&quot;No Songs has been added
 in this Album&quot; .If songs are available for the album, then we pick the first record of song and pass the song name to playMusic method.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;audio&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;audioPlay&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Show&nbsp;Music&nbsp;&nbsp;&nbsp;Details&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showMusicAlbum&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;showMusicAlbum(AlbumNames,&nbsp;ImageName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumName&nbsp;=&nbsp;AlbumNames;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.AlbumImage&nbsp;=&nbsp;ImageName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Get&nbsp;the&nbsp;Music&nbsp;Play&nbsp;list&nbsp;by&nbsp;Albums&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/MusicAPI/getMusicSelectALL/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;AlbumName:&nbsp;$scope.AlbumName&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.MusicData&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.MusicData.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.showAlbum&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.showMusics&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.showButton&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.songsCount=$scope.MusicData.length;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.CurrentSong&nbsp;=&nbsp;$scope.MusicData[$scope.selectedSongIndex].MusicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.playMusic($scope.selectedSongIndex,&nbsp;$scope.CurrentSong);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;No&nbsp;Songs&nbsp;has&nbsp;been&nbsp;added&nbsp;in&nbsp;this&nbsp;Album&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.songsCount&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;In playMusic, we get the music file name and play the current selected songs.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Play&nbsp;Songs&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.playMusic&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(indexnumber,&nbsp;musicFileName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;indexnumber;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.CurrentSong&nbsp;=&nbsp;musicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongstoPlay&nbsp;=&nbsp;<span class="js__string">&quot;/uploads/&quot;</span>&nbsp;&#43;&nbsp;musicFileName;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.load();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.play();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.addEventListener(<span class="js__string">'ended'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.selectedSongIndex&nbsp;&lt;&nbsp;$scope.songsCount)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;$scope.selectedSongIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.CurrentSong&nbsp;=&nbsp;$scope.MusicData[$scope.selectedSongIndex].MusicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongstoPlay&nbsp;=&nbsp;<span class="js__string">&quot;/uploads/&quot;</span>&nbsp;&#43;&nbsp;musicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.load();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.play();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="159043" src="159043-18.png" alt="" width="185" height="42"></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Play Next Song<br>
</strong><span>In Next image click, we call the nextSong method .In this method, &nbsp;we check and increment the selected song index to play the next song .We will pass the song name to playMusic method to play the song.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//next&nbsp;Song&nbsp;Play&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.nextSong&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.selectedSongIndex&nbsp;&lt;&nbsp;$scope.songsCount)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;$scope.selectedSongIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.CurrentSong&nbsp;=&nbsp;$scope.MusicData[$scope.selectedSongIndex].MusicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.playMusic($scope.selectedSongIndex,&nbsp;$scope.CurrentSong);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Play Previous Song</strong><span>&nbsp;</span><br>
<span>In Previous image click, we call the previousSong method .In this method, we check and decrement the selected song index to play the previous song .We will pass the song name to playMusic method to play the song.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Previous&nbsp;Song&nbsp;Play&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.previousSong&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>($scope.selectedSongIndex&gt;<span class="js__num">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;$scope.selectedSongIndex&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectedSongIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.CurrentSong&nbsp;=&nbsp;$scope.MusicData[$scope.selectedSongIndex].MusicFileName;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.playMusic($scope.selectedSongIndex,&nbsp;$scope.CurrentSong);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Pause Current Song</strong><br>
<span>In stop image click, we call the pauseMusic method .In this method, we pause the currently playing song.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Pause&nbsp;Songs&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;$scope.pauseMusic&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.pause();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Play Current Song</strong>&nbsp;</div>
<p><span>In play image click, we call the playCurrent method .In this method we continue playing of paused song.</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//play&nbsp;Current&nbsp;Songs&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.playCurrent&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;audio.play();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>shanuMusicPlayerMVC.zip</span> </li></ul>
<h1>More Information</h1>
<p><em><strong>Conclusion&nbsp;</strong><br>
<br>
<span>Hope you all like this Shanu Music Player web based system.</span><br>
<br>
<span>This is simple web based music system developed using MVC and AngularJS. This application can be extended to add more features, like recently played songs and most played songs etc. as per your requirement.</span></em></p>
