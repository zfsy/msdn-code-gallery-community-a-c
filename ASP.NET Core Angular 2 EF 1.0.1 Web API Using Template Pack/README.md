# ASP.NET Core Angular 2 EF 1.0.1 Web API Using Template Pack
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Entity Framework
- ASP.NET Web API
- Angular 2
- ASP.NET Core 1.0.1
## Topics
- Entity Framework
- ASP.NET Web API
- ASP.NET Core
- Angular2
## Updated
- 01/16/2017
## Description

<h1>Introduction</h1>
<p><img id="165947" src="165947-19.png" alt="" width="589" height="209"></p>
<p>In this article let&rsquo;s see how to create our first ASP.NET Core Angular 2 Starter Application (.NET Core) using Template pack using Entity Framework 1.0.1 and Web API to display data from the database to our Angular2 and ASP.NET Core web application.<br>
<br>
<span style="text-decoration:underline"><strong>Note<br>
<br>
</strong></span>Kindly read our previous article which explains &nbsp;in depth about&nbsp;<a href="https://code.msdn.microsoft.com/ASPNET-Core-Template-Pack-71bcde34?redir=0" target="_blank"><span>Getting Started With ASP.NET Core Template Pack</span></a><br>
<br>
<strong>In this article we will see about:</strong></p>
<ul>
<li>Creating sample Database and Table in SQL Server to display in our web application.
</li><li>How to create ASP.NET Core Angular 2 Starter Application (.NET Core) using Template pack
</li><li>Creating EF, DBContext Class and Model Class. </li><li>Creating WEB API </li><li>Creating our First Component TypeScript file to get WEB API JSON result using Http Module.
</li><li>Creating our first Component HTML file to bind final result. </li></ul>
<h1><span>Building the Sample</span></h1>
<h1><strong>Prerequisites</strong></h1>
<p>Make sure you have installed all the prerequisites in your computer. If not, then download and install all of them, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2015 with Update 3 from this&nbsp;<a href="https://www.visualstudio.com/downloads/" target="_blank">link</a>.
</li><li>If you have Visual Studio 2015 and have not yet updated with update 3, download and install the Visual Studio 2015 Update 3 from this&nbsp;<a href="https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs" target="_blank"><span>link</span></a>.
</li><li><a href="https://www.microsoft.com/net/core#windowsvs2015" target="_blank">Download</a>&nbsp;and install .NET Core 1.0.1
</li><li><a href="https://blogs.msdn.microsoft.com/typescript/2016/09/22/announcing-typescript-2-0/" target="_blank"></a><a href="https://blogs.msdn.microsoft.com/typescript/2016/09/22/announcing-typescript-2-0/" target="_blank">Download</a>&nbsp;and install TypeScript
 2.0 </li><li>Download and install Node.js v4.0 or above. I have installed V6.9.1 (<a href="https://nodejs.org/en/" target="_blank"><span>Download link</span></a>).
</li><li>Download and install Download ASP.NET Core Template Pack visz file from this&nbsp;<a href="https://marketplace.visualstudio.com/items?itemName=MadsKristensen.ASPNETCoreTemplatePack" target="_blank">link</a>.
</li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h1><strong>Step 1 Create a Database and Table</strong></h1>
<p><strong>&nbsp;</strong><span>We will be using our SQL Server database for our WEB API and EF. First, we create a database named StudentsDB and a table as StudentMaster. Here is the SQL script to create Database table and sample record insert query in our
 table. Run the below query in your local SQL server to create Database and Table to be used in our project.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">USE</span>&nbsp;<span class="sql__keyword">MASTER</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;&nbsp;&nbsp;&nbsp;
--<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">Check</span>&nbsp;<span class="sql__keyword">for</span>&nbsp;<span class="sql__id">the</span>&nbsp;<span class="sql__keyword">Database</span>&nbsp;<span class="sql__keyword">Exists</span>.<span class="sql__keyword">If</span>&nbsp;<span class="sql__id">the</span>&nbsp;<span class="sql__keyword">database</span>&nbsp;<span class="sql__keyword">is</span>&nbsp;<span class="sql__id">exist</span>&nbsp;<span class="sql__keyword">then</span>&nbsp;<span class="sql__keyword">drop</span>&nbsp;<span class="sql__keyword">and</span>&nbsp;<span class="sql__keyword">create</span>&nbsp;<span class="sql__keyword">new</span>&nbsp;<span class="sql__id">DB</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__keyword">EXISTS</span>(<span class="sql__keyword">SELECT</span>[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span>&nbsp;<span class="sql__id">sys</span>.<span class="sql__keyword">databases</span>&nbsp;<span class="sql__keyword">WHERE</span>[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'StudentsDB'</span>)&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">DROP</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;<span class="sql__id">StudentsDB</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;<span class="sql__id">StudentsDB</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">USE</span>&nbsp;<span class="sql__id">StudentsDB</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;&nbsp;&nbsp;&nbsp;
--<span class="sql__number">1</span>)&nbsp;////////////&nbsp;<span class="sql__id">StudentMasters</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__keyword">EXISTS</span>(<span class="sql__keyword">SELECT</span>[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span>&nbsp;<span class="sql__id">sys</span>.<span class="sql__keyword">tables</span>&nbsp;<span class="sql__keyword">WHERE</span>[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'StudentMasters'</span>)&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">DROP</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;<span class="sql__id">StudentMasters</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>[<span class="sql__id">dbo</span>].[<span class="sql__id">StudentMasters</span>](&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">StdID</span>]&nbsp;<span class="sql__keyword">INT</span>&nbsp;<span class="sql__id">IDENTITY</span>&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>,&nbsp;[<span class="sql__id">StdName</span>][<span class="sql__keyword">varchar</span>](<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;[<span class="sql__id">Email</span>][<span class="sql__keyword">varchar</span>](<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;[<span class="sql__id">Phone</span>][<span class="sql__keyword">varchar</span>](<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;[<span class="sql__id">Address</span>][<span class="sql__keyword">varchar</span>](<span class="sql__number">200</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--<span class="sql__keyword">insert</span>&nbsp;<span class="sql__id">sample</span>&nbsp;<span class="sql__keyword">data</span>&nbsp;<span class="sql__keyword">to</span>&nbsp;<span class="sql__id">Student</span>&nbsp;<span class="sql__keyword">Master</span>&nbsp;<span class="sql__keyword">table</span>&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">StudentMasters</span>]([<span class="sql__id">StdName</span>],&nbsp;[<span class="sql__id">Email</span>],&nbsp;[<span class="sql__id">Phone</span>],&nbsp;[<span class="sql__id">Address</span>])&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>(<span class="sql__string">'Shanu'</span>,&nbsp;<span class="sql__string">'syedshanumcain@gmail.com'</span>,&nbsp;<span class="sql__string">'01030550007'</span>,&nbsp;<span class="sql__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">StudentMasters</span>]([<span class="sql__id">StdName</span>],&nbsp;[<span class="sql__id">Email</span>],&nbsp;[<span class="sql__id">Phone</span>],&nbsp;[<span class="sql__id">Address</span>])&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>(<span class="sql__string">'Afraz'</span>,&nbsp;<span class="sql__string">'Afraz@afrazmail.com'</span>,&nbsp;<span class="sql__string">'01030550006'</span>,&nbsp;<span class="sql__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">StudentMasters</span>]([<span class="sql__id">StdName</span>],&nbsp;[<span class="sql__id">Email</span>],&nbsp;[<span class="sql__id">Phone</span>],&nbsp;[<span class="sql__id">Address</span>])&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>(<span class="sql__string">'Afreen'</span>,&nbsp;<span class="sql__string">'Afreen@afreenmail.com'</span>,&nbsp;<span class="sql__string">'01030550005'</span>,&nbsp;<span class="sql__string">'Madurai,India'</span>)&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">select</span>&nbsp;*&nbsp;<span class="sql__keyword">from</span>[<span class="sql__id">StudentMasters</span>]&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-size:2em">Step 2 Create ASP.NET Core Angular 2 application</strong></div>
<p>&nbsp;</p>
<p>After installing all the prerequisites listed above and ASP.NET Core Template, click Start &gt;&gt; Programs &gt;&gt; Visual Studio 2015 &gt;&gt; Visual Studio 2015, on your desktop. Click New &gt;&gt; Project. Select Web &gt;&gt; ASP.NET Core Angular 2
 Starter. Enter your project name and click OK.</p>
<p><img id="165948" src="165948-1.png" alt="" width="503" height="246"></p>
<p><span>After creating ASP.NET Core Angular 2 application, wait for a few seconds. You will see that all the dependencies are automatically restoring.</span></p>
<p><img id="165949" src="165949-2.png" alt="" width="244" height="300"></p>
<h1><strong>What is new in ASP.NET Core Template Pack ?</strong></h1>
<p><img id="165950" src="165950-3.png" alt="" width="253" height="569"></p>
<h2><strong>WWWroot<br>
</strong></h2>
<p><span>We can see all the CSS,JS files are added under the &ldquo;dist&rdquo; folder .&rdquo;main-client.js&rdquo; file is the important file as all the Angular2 results will be compiled and results will be loaded from this &ldquo;js&rdquo; file to our html
 file.</span></p>
<p><img id="165951" src="165951-3_0.png" alt="" width="260" height="173"></p>
<h2><strong>ClientApp Folder</strong></h2>
<p><strong>&nbsp;</strong>We can see a new folder Client App inside our project solution. This folder contains all Angular2 related applications like Modules, Components and etc. We can add all our Angular 2 related Modules, Component, Template, and HTML files
 &nbsp;under this folder. We can see in detail about how to create our own Angular2 application here, below, in our article.</p>
<p><span>In Components folder under app folder we can see many subfolders like app. counter, fetchdata, home and navmenu. By default, all this sample applications have &nbsp;been created and when we run our application we can see all the sample Angular2 application
 results.&nbsp;</span></p>
<p><img id="165952" src="165952-3_1.png" alt="" width="204" height="185"></p>
<p><span>When we run the application, we can see navigation in the left side and the right side contains data. All the Angular2 samples will be loaded from the above folder.</span></p>
<p><img id="165953" src="165953-3-2.png" alt="" width="560" height="203"></p>
<h2><strong>Controllers Folder: </strong></h2>
<p><strong>&nbsp;</strong>This is our MVC Controller folder, we can create both MVC and Web API Controller in this folder.</p>
<h2><strong>&nbsp;View Folder:</strong></h2>
<p>This is our MVC View folder.</p>
<h2><strong>project.json : </strong></h2>
<p><strong>&nbsp;</strong>ASP.NET Core dependency list can be found in this file, We will be adding our Entity Frame work in dependency section of this file.</p>
<h2><strong>package.json : </strong></h2>
<p><strong>&nbsp;</strong>This is another important file as all Angular2 related dependency list will be added here by default all the Angular2 related dependency&rsquo;s has been added here in ASP.NET Core Template pack.</p>
<h2><strong>appsettings.json : </strong></h2>
<p><strong>&nbsp;</strong>We can add our database connection string in this appsetting.json file.&nbsp;</p>
<p>We will be using all this in our project to create, build and run our Angular 2 with ASP.NET Core Template Pack, WEB API and EF 1.0.1<strong>
</strong></p>
<h1><strong>Step 3 Creating Entity Framework</strong></h1>
<p><strong>&nbsp;</strong><span>Add Entity Framework Packages</span><br>
<br>
<span>To add our Entity Framework Packages in our ASP.NET Core application, open the Project.JSON File and in dependencies add the below line.</span><br>
<br>
<span style="text-decoration:underline"><strong>Note</strong></span><span>&nbsp;Here we have used EF version 1.0.1.&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml">&quot;Microsoft.EntityFrameworkCore.SqlServer&quot;:&nbsp;&quot;1.0.1&quot;,&nbsp;&nbsp;&nbsp;
&quot;Microsoft.EntityFrameworkCore.Tools&quot;:&nbsp;&quot;1.0.0-preview2-final&quot;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="165954" src="165954-4.png" alt="" width="317" height="230"></div>
<p><span>When we save the project,.json file we can see the reference is restored.</span></p>
<p>&nbsp;</p>
<p><img id="165955" src="165955-5.png" alt="" width="201" height="56"></p>
<p><span>After few second we can see Entity framework package has been restored and all references have been added.</span></p>
<p><img id="165956" src="165956-6.png" alt="" width="333" height="149"></p>
<h2><strong>Adding Connection String</strong></h2>
<p><strong>&nbsp;</strong>To add the connection string with our SQL connection open the &ldquo;appsettings.json&rdquo; file .Yes this is the JSON file and this file looks like the below image by default.</p>
<p><img id="165957" src="165957-7.png" alt="" width="305" height="181"></p>
<p><span>In this appsettings.json file add our connection string&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js"><span class="js__string">&quot;ConnectionStrings&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;DefaultConnection&quot;</span>:&nbsp;<span class="js__string">&quot;Server=YOURDBSERVER;Database=StudentsDB;user&nbsp;id=SQLID;password=SQLPWD;Trusted_Connection=True;MultipleActiveResultSets=true;&quot;</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>,&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="text-decoration:underline"><strong>Note</strong></span><span>&nbsp;</span><br>
<br>
<span>Change the SQL connection string as per your local connection.</span></div>
<p><img id="165958" src="165958-8.png" alt="" width="559" height="171"></p>
<p>&nbsp;</p>
<p><span>Next step is we create a folder named &ldquo;Data&rdquo; to create our model and DBContext class.</span></p>
<p><img id="165959" src="165959-10.png" alt="" width="207" height="140"></p>
<h2><strong>Creating Model Class for Student</strong></h2>
<p><span>We can create a model by adding a new class file in our DataFolder. Right Click Data folder and click Add&gt;Click Class. Enter the class name as StudentMasters and click Add.</span></p>
<p><img id="165960" src="165960-11.png" alt="" width="469" height="251"></p>
<p><span>Now in this class we first create property variable, and add student. We will be using this in our WEB API controller.&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
usingSystem.Collections.Generic;&nbsp;&nbsp;&nbsp;
usingSystem.Linq;&nbsp;&nbsp;&nbsp;
usingSystem.Threading.Tasks;&nbsp;&nbsp;&nbsp;
usingSystem.ComponentModel.DataAnnotations;&nbsp;&nbsp;&nbsp;
namespace&nbsp;Angular2ASPCORE.Data&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;publicclassStudentMasters&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicintStdID&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Name&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicstringStdName&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Email&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicstring&nbsp;Email&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Display(Name&nbsp;=&nbsp;<span class="js__string">&quot;Phone&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicstring&nbsp;Phone&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicstring&nbsp;Address&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;<strong>Creating Database Context</strong></h2>
<div class="endscriptcode"><span>DBContextis Entity Framework Class for establishing connection to database.</span><br>
<br>
<span>We can create a DBContext class by adding a new class file in our Data Folder. Right Click Data folder and click Add&gt;Click Class. Enter the class name as StudentContext and click Add.</span></div>
<p><img id="165961" src="165961-12.png" alt="" width="495" height="246"></p>
<p>&nbsp;</p>
<p><span>In this class we inherit DbContext and created Dbset for our students table.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
usingSystem.Collections.Generic;&nbsp;&nbsp;&nbsp;
usingSystem.Linq;&nbsp;&nbsp;&nbsp;
usingSystem.Threading.Tasks;&nbsp;&nbsp;&nbsp;
usingMicrosoft.EntityFrameworkCore;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;Angular2ASPCORE.Data&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;publicclassstudentContext:&nbsp;DbContext&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicstudentContext(DbContextOptions&nbsp;&lt;&nbsp;studentContext&nbsp;&gt;&nbsp;options):&nbsp;base(options)&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicstudentContext()&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicDbSet&nbsp;&lt;&nbsp;StudentMasters&nbsp;&gt;&nbsp;StudentMasters&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-size:1.5em">Startup.CS</strong></div>
<p>&nbsp;</p>
<p><span>Now we need to add our database connection string and provider as SQL SERVER.To add this we add the below code in Startup.cs file under ConfigureServices method.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">services.AddDbContext&nbsp;&lt;&nbsp;studentContext&nbsp;&gt;&nbsp;(options&nbsp;=&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;options.UseSqlServer(Configuration.GetConnectionString(<span class="js__string">&quot;DefaultConnection&quot;</span>)));&nbsp;</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;<strong>Step 4 Creating Web API</strong></h1>
<div class="endscriptcode"><span>To create our WEB API Controller, right click Controllers folder. Click Add and click New Item.</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="165962" src="165962-13.png" alt="" width="390" height="274"></p>
<p><span>Click ASP.NET in right side &gt; Click Web API Controller Class. Enter the name as &ldquo;StudentMastersAPI.cs&rdquo; and click Add.</span></p>
<p><img id="165963" src="165963-14.png" alt="" width="421" height="210"></p>
<p><span>In this we are using only the Get method to get all the student results from the database and bind the final result using Angular2 to html file.</span><br>
<br>
<span>Here in web API Class only add the get method to get all the student details. Here is the code to get all student results using WEB API.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;
usingSystem.Collections.Generic;&nbsp;&nbsp;&nbsp;
usingSystem.Linq;&nbsp;&nbsp;&nbsp;
usingSystem.Threading.Tasks;&nbsp;&nbsp;&nbsp;
usingMicrosoft.AspNetCore.Mvc;&nbsp;&nbsp;&nbsp;
using&nbsp;Angular2ASPCORE.Data;&nbsp;&nbsp;&nbsp;
usingMicrosoft.EntityFrameworkCore;&nbsp;&nbsp;&nbsp;
usingMicrosoft.AspNetCore.Http;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;For&nbsp;more&nbsp;information&nbsp;on&nbsp;enabling&nbsp;Web&nbsp;API&nbsp;for&nbsp;empty&nbsp;projects,&nbsp;visit&nbsp;http://go.microsoft.com/fwlink/?LinkID=397860&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;Angular2ASPCORE.Controllers&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Produces(<span class="js__string">&quot;application/json&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;api/StudentMastersAPI&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;publicclassStudentMastersAPI:&nbsp;Controller&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;privatereadonlystudentContext&nbsp;_context;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicStudentMastersAPI(studentContext&nbsp;context)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context&nbsp;=&nbsp;context;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/values&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="js__string">&quot;Student&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;publicIEnumerable&nbsp;&lt;&nbsp;StudentMasters&nbsp;&gt;&nbsp;GetStudentMasters()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_context.StudentMasters;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;To test it we can run our project and copy the get method api path; here we can see our API path for get is api/StudentMastersAPI/Student</div>
<p><br>
<span>Run the program and paste the above API path to test our output.</span></p>
<p>&nbsp;</p>
<p><img id="165964" src="165964-15.png" alt="" width="492" height="120"></p>
<h1><strong>Working with Angular2</strong></h1>
<p><span>We create all Angular2 related Apps, Modules, Services, Components and html templates under ClientApp/App folder.</span><br>
<br>
<span>We create &ldquo;students&rdquo; folder under app folder to create our typescript and html file for displaying Student details.</span><br>
<img id="165965" src="165965-16.png" alt="" width="193" height="167"></p>
<h1><strong>Step 5 Creating Component TypeScript</strong></h1>
<p><span>Right Click on student folder and click on add new Item. Select Client-side from left side and select TypeScript File and name the file &ldquo;students.component.ts&rdquo; and click Add.</span></p>
<p><img id="165967" src="165967-18.png" alt="" width="459" height="240"></p>
<p><span>In students.component.ts file we have three parts:</span></p>
<ol>
<li>import part </li><li>component part </li><li>class for writing our business logics. </li></ol>
<p>First we import Angular files to be used in our component -- &nbsp;here we import http for using http client in our Angular2 component.&nbsp;<br>
<br>
In component we have selector and template. Selector is to give a name for this app and in our html file we use this selector name to display in our html page.<br>
<br>
In template we give our output html file name Here we will create an html file as &ldquo;students.component.html&rdquo;.<br>
<br>
Export Class is the main class where we do all our business logic and variable declaration to be used in our component template. In this class we get the API method result and bind the result to the student array.&nbsp;</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Component&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;&nbsp;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Http&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">&quot;@angular/http&quot;</span>;&nbsp;&nbsp;&nbsp;
@Component(<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selector:&nbsp;<span class="js__string">'students'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;template:&nbsp;require(<span class="js__string">'./students.component.html'</span>)&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
exportclassstudentsComponent&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;student:&nbsp;StudentMasters[]&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;myName:&nbsp;string;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;constructor(http:&nbsp;Http)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.myName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;http.get(<span class="js__string">'/api/StudentMastersAPI/Student'</span>).subscribe(result&nbsp;=&gt;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.student&nbsp;=&nbsp;result.json();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
exportinterfaceStudentMasters&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;stdID:&nbsp;number;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;stdName:&nbsp;string;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;email:&nbsp;string;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;phone:&nbsp;string;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;address:&nbsp;string;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
</h1>
<h1><strong>Step 6 Creating Component HTML File</strong></h1>
<p><span>Right Click on student folder and click on add new Item. Select Client-side from left side and select html File and name the file as &ldquo;students.component.html&rdquo; and click Add.</span></p>
<p><img id="165968" src="165968-17.png" alt="" width="395" height="238"></p>
<p><span>Write the below html code to bind the result in our html page</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;h1&gt;Angular&nbsp;<span class="js__num">2</span>&nbsp;<span class="js__statement">with</span>&nbsp;ASP.NET&nbsp;Core&nbsp;Template&nbsp;Pack,&nbsp;WEB&nbsp;API&nbsp;and&nbsp;EF&nbsp;<span class="js__num">1.0</span><span class="js__num">.1</span>&nbsp;&nbsp;&lt;/h1&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;h2&gt;My&nbsp;Name&nbsp;is&nbsp;:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>myName<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/h2&gt;&nbsp;
&lt;hr&nbsp;/&gt;&nbsp;
&lt;h1&gt;Students&nbsp;Details&nbsp;:&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;
&lt;p&nbsp;*ngIf=<span class="js__string">&quot;!student&quot;</span>&gt;&lt;em&gt;Loading&nbsp;Student&nbsp;Details&nbsp;please&nbsp;Wait&nbsp;!&nbsp;...&lt;<span class="js__reg_exp">/em&gt;&lt;/</span>p&gt;&nbsp;
&nbsp;
&lt;table&nbsp;class=<span class="js__string">'table'</span>&nbsp;style=<span class="js__string">&quot;background-color:#FFFFFF;&nbsp;border:2px&nbsp;#6D7B8D;&nbsp;padding:5px;width:99%;table-layout:fixed;&quot;</span>&nbsp;cellpadding=<span class="js__string">&quot;2&quot;</span>&nbsp;cellspacing=<span class="js__string">&quot;2&quot;</span>&nbsp;*ngIf=<span class="js__string">&quot;student&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;style=<span class="js__string">&quot;height:&nbsp;30px;&nbsp;background-color:#336699&nbsp;;&nbsp;color:#FFFFFF&nbsp;;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;100&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Student&nbsp;ID&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Student&nbsp;Name&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;240&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Email&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;120&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Phone&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;width=<span class="js__string">&quot;340&quot;</span>&nbsp;align=<span class="js__string">&quot;center&quot;</span>&gt;Address&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tbody&nbsp;*ngFor=<span class="js__string">&quot;let&nbsp;StudentMasters&nbsp;&nbsp;of&nbsp;student&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.stdID<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;left&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.stdName<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;left&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.email<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;center&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.phone<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;align=<span class="js__string">&quot;left&quot;</span>&nbsp;style=<span class="js__string">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;style=<span class="js__string">&quot;color:#9F000F&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>StudentMasters.address<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;
&lt;/table&gt;&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;<strong>Step 7 Adding Navigation menu</strong></h1>
<div class="endscriptcode"><span>We can add our newly created student details menu in the existing menu.</span><br>
<br>
<span>To add our new navigation menu open the &ldquo;navmenu.component.html&rdquo; under navmenumenu.write the below code to add our navigation menu link for students.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;li[routerLinkActive]=<span class="js__string">&quot;['link-active']&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;a[routerLink]=<span class="js__string">&quot;['/students']&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;spanclass=<span class="js__string">'glyphiconglyphicon-th-list'</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;Students&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/a&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/li&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="165969" src="165969-20.png" alt="" width="454" height="247"></div>
<p>&nbsp;</p>
<h1><strong>Step 8 App Module</strong></h1>
<p><span>App Module is the root for all files and we can find the app.module.ts under ClientApp\app, and import our students component</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">import&nbsp;<span class="js__brace">{</span>&nbsp;NgModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/core'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;RouterModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'@angular/router'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;UniversalModule&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'angular2-universal'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;AppComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/app/app.component'</span>&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;NavMenuComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/navmenu/navmenu.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;HomeComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/home/home.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;FetchDataComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/fetchdata/fetchdata.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;CounterComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/counter/counter.component'</span>;&nbsp;
import&nbsp;<span class="js__brace">{</span>&nbsp;studentsComponent&nbsp;<span class="js__brace">}</span>&nbsp;from&nbsp;<span class="js__string">'./components/students/students.component'</span>;&nbsp;
&nbsp;
@NgModule(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bootstrap:&nbsp;[&nbsp;AppComponent&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;declarations:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavMenuComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CounterComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FetchDataComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HomeComponent,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentsComponent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imports:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UniversalModule,&nbsp;<span class="js__sl_comment">//&nbsp;Must&nbsp;be&nbsp;first&nbsp;import.&nbsp;This&nbsp;automatically&nbsp;imports&nbsp;BrowserModule,&nbsp;HttpModule,&nbsp;and&nbsp;JsonpModule&nbsp;too.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RouterModule.forRoot([&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">''</span>,&nbsp;redirectTo:&nbsp;<span class="js__string">'home'</span>,&nbsp;pathMatch:&nbsp;<span class="js__string">'full'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'home'</span>,&nbsp;component:&nbsp;HomeComponent&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'counter'</span>,&nbsp;component:&nbsp;CounterComponent&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'fetch-data'</span>,&nbsp;component:&nbsp;FetchDataComponent&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'students'</span>,&nbsp;component:&nbsp;studentsComponent&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;path:&nbsp;<span class="js__string">'**'</span>,&nbsp;redirectTo:&nbsp;<span class="js__string">'home'</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
<span class="js__brace">}</span>)&nbsp;
export&nbsp;class&nbsp;AppModule&nbsp;<span class="js__brace">{</span>&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<h1><strong>Step 9 Build and run the Application</strong></h1>
<p><span>Build and run the application and you can see our Student page will be loaded with all Student information.</span></p>
<p>&nbsp;</p>
<p><img id="165947" src="165947-19.png" alt="" width="589" height="209"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>Angular2ASPCORE.zip</span> </li></ul>
<h1>More Information</h1>
<p><em><span>First create the Database and Table in your SQL Server. You can run the SQL Script from this article to create StudentsDB database and StudentMasters Table and also don&rsquo;t forget to change the Connection string from &ldquo;appsettings.json&quot;.</span></em></p>
