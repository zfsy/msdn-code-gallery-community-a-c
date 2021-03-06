# ASP.NET Core - Getting Started With Blazor
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Visual Studio 2017
- ASP.NET Core 2.0
- Blazor
## Topics
- Web Development
## Updated
- 02/23/2019
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Microsoft has recently announced the release of a new .NET web framework &ndash; Blazor. In this article, we will understand Blazor and setup Blazor development environment in our machine and execute our first program in ASP.NET
 core using Blazor and Visual Studio 2017. We will also create a sample calculator application using Blazor.</span></p>
<h1>What is Blazor?</h1>
<p><span style="font-size:small">Blazor is a new .NET web framework for creating client-side applications using C#/Razor and HTML that runs in the browser with&nbsp;<a href="http://webassembly.org/" target="_blank">WebAssembly</a>. It can simplify the process
 of creating single page application (SPA) and at the same time enables full stack web development using .NET.</span></p>
<p><span style="font-size:small">Using .NET for developing Client-side application has multiple advantages that are mentioned below,</span></p>
<ol>
<li><span style="font-size:small">.NET offers a range of API and tools across all platform that are stable and easy to use.</span>
</li><li><span style="font-size:small">The modern languages such as C# and F# offer a lot of features that make programming easier and interesting for developers.</span>
</li><li><span style="font-size:small">The availability of one of the best IDE in form of Visual Studio provides a great .NET development experience across multiple platforms such as Windows, Linux, and MacOS.</span>
</li><li><span style="font-size:small">.NET provides features such as speed, performance, security, scalability, and reliability in web development that makes full stack development easier.&nbsp;</span>
</li></ol>
<div><span style="font-size:small">Microsoft defined Blazor as an experimental project and since it is still in alpha phase (as of today March 30, 2018) so, it should not be used in a production environment.</span></div>
<div><span style="font-size:small"><br>
</span></div>
<h1>What is WebAssembly?</h1>
<div></div>
<div></div>
<div><span style="font-size:small">WebAssembly (abbreviated Wasm) is low-level assembly-like language with a compact binary format that can run in modern web browser. Since it is a low-level binary code, it cannot be read/written by humans but we can compile
 the code from other languages to WebAssembly to facilitate their execution on the browser. It is a subset of JavaScript and is designed to complement and run alongside JavaScript. It enables us to run code written in multiple language on the web at near native
 speed.&nbsp;WebAssembly is developed as a web standard and is supported by all the major browsers without plugins.</span></div>
<div><span style="font-size:small"><br>
</span></div>
<h1>Why use Blazor?</h1>
<div></div>
<div></div>
<div><span style="font-size:small">Blazor makes web development easier and more productive by providing a full stack web development with .NET. It runs in all browsers on the real .NET runtime and have full support for .NET Standard without the need of any
 extra plugin. Blazor is fast, have reusable components and is open-source with a great support from the community.&nbsp;Blazor also supports features of a SPA framework such as:</span></div>
<div>
<ul>
<li><span style="font-size:small">RoutingLayouts</span> </li><li><span style="font-size:small">Forms and validation</span> </li><li><span style="font-size:small">JavaScript interop</span> </li><li><span style="font-size:small">Build on save</span> </li><li><span style="font-size:small">Server-side rendering</span> </li><li><span style="font-size:small">Dependency Injection</span> </li></ul>
</div>
<div><span style="font-size:small">
<h1>Prerequisites</h1>
<div>
<ul>
<li>Install .NET Core 2.1 Preview 1 SDK from&nbsp;<a href="https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview1" target="_blank">here</a>
</li><li>Install latest preview of Visual Studio 2017 (15.7) from&nbsp;<a href="https://www.visualstudio.com/vs/preview" target="_blank">here</a>
</li></ul>
</div>
<div>
<p>The Blazor is not supported on versions below Visual Studio 2017 v15.7</p>
<div>
<h1>Getting Started with Blazor</h1>
To create our first Blazor application we need to install &quot;ASP.NET Core Blazor Language Services extension&quot; from&nbsp;<a href="https://marketplace.visualstudio.com/items?itemName=aspnet.blazor" target="_blank">here</a>.</div>
<div>Install this extension and it will be added to your VS 2017.<br>
<br>
Open Visual Studio and select File &gt;&gt; New &gt;&gt; Project.&nbsp;After selecting the project, a &quot;New Project&quot; dialog will open. Select .NET Core inside Visual C# menu from the left panel.&nbsp;Then, select &ldquo;ASP.NET Core Web Application&rdquo; from
 available project types. Put the name of the project as&nbsp;<em>BlazorDemo&nbsp;</em>and press OK.</div>
<div></div>
<div></div>
<div><img id="199331" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199331/1/create_1.png" alt="" width="650" height="398"></div>
<div></div>
<div></div>
<div></div>
<div></div>
<div></div>
<div></div>
<div></div>
<div>After clicking on OK, a new dialog will open asking you to select the project template. You can observe two drop-down menus at the top left of the template window. Select &ldquo;.NET Core&rdquo;</div>
<div>and &ldquo;ASP.NET Core 2.0&rdquo; from these dropdowns. Then, select &ldquo;Blazor&rdquo; template and press OK.</div>
<div></div>
<div></div>
<div></div>
<div><img id="199333" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199333/1/create_2.png" alt="" width="650" height="426"></div>
<p><img id="197285" src="197285-create_2.png" alt=""></p>
</div>
</span></div>
<div><span style="font-size:small">Now, our first Blazor project will be created. You can observe the folder structure in Solution Explorer as shown in the below image.</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div></div>
<div><span style="font-size:small"><img id="199332" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199332/1/solutionexp_1.png" alt="" width="244" height="434"><br>
</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div></div>
<div><span style="font-size:small"><span>You can see that we have a &ldquo;Pages&rdquo; folder. We will be adding our view pages to this folder only and these pages will be rendered on the web. Execute the program, it will be open the browser and you will see
 a page similar to the one shown below.</span></span></div>
<div><span style="font-size:small"><span><br>
</span></span></div>
<div></div>
<div><span style="font-size:small"><span><img id="199334" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199334/1/execution_1.png" alt="" width="650" height="235"><br>
</span></span></div>
<div><span style="font-size:small"><span><br>
</span></span></div>
<div><span style="font-size:small">Here you can see a navigation menu on the left side, which contains the navigation links to all the pages we have in our application. By default, we have &ldquo;Counter&rdquo; and &ldquo;Fetch Data&rdquo; pages provided.&nbsp;We
 are going to add a &ldquo;Calculator&rdquo; page for our sample calculator application.</span></div>
<h1>Create a Sample Calculator Using Blazor</h1>
<p><span style="font-size:small">We are going to create a basic calculator app, which is able to do addition, subtraction, multiplication, and division.&nbsp;Right click on Pages folder and select Add &gt;&gt; New Item. An &ldquo;Add New Item&rdquo; dialog
 box will open. Select&nbsp;<em>Web</em>&nbsp;from the left panel,&nbsp;then select &ldquo;Razor View&rdquo; from templates panel and put the name as&nbsp;<em>Calculator.cshtml</em>. Press Add.</span></p>
<p><span style="font-size:small"><img id="199335" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199335/1/addview.png" alt="" width="650" height="398"><br>
</span></p>
<p><span style="font-size:small">Open&nbsp;</span><em style="font-size:small">Calculator.cshtml&nbsp;</em><span style="font-size:small">and put the following code into it.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@page&nbsp;&quot;/calculator&quot;&nbsp;
&nbsp;
<span class="html__tag_start">&lt;h1</span><span class="html__tag_start">&gt;</span>Basic&nbsp;Calculator&nbsp;Demo&nbsp;Using&nbsp;Blazor<span class="html__tag_end">&lt;/h1&gt;</span>&nbsp;
<span class="html__tag_start">&lt;hr</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>First&nbsp;Number<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-4&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;Enter&nbsp;First&nbsp;Number&quot;</span>&nbsp;<span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@num1&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Second&nbsp;Number<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-4&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;Enter&nbsp;Second&nbsp;Number&quot;</span>&nbsp;<span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@num2&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span>Result<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-4&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;readonly&nbsp;<span class="html__attr_name">bind</span>=<span class="html__attr_value">&quot;@finalresult&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-2&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;@AddNumbers&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&quot;</span><span class="html__tag_start">&gt;</span>Add&nbsp;(&#43;)<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-2&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;@SubtractNumbers&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-primary&quot;</span><span class="html__tag_start">&gt;</span>Subtract&nbsp;(&minus;)<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-2&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;@MultiplyNumbers&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-success&nbsp;&quot;</span><span class="html__tag_start">&gt;</span>Multiply&nbsp;(X)<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-sm-2&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;@DivideNumbers&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-info&quot;</span><span class="html__tag_start">&gt;</span>Divide&nbsp;(X)<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
@functions&nbsp;{&nbsp;
&nbsp;
string&nbsp;num1;&nbsp;
string&nbsp;num2;&nbsp;
string&nbsp;finalresult;&nbsp;
&nbsp;
void&nbsp;AddNumbers()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;finalresult&nbsp;=&nbsp;(Convert.ToDouble(num1)&nbsp;&#43;&nbsp;Convert.ToDouble(num2)).ToString();&nbsp;
}&nbsp;
&nbsp;
void&nbsp;SubtractNumbers()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;finalresult&nbsp;=&nbsp;(Convert.ToDouble(num1)&nbsp;-&nbsp;Convert.ToDouble(num2)).ToString();&nbsp;
}&nbsp;
&nbsp;
void&nbsp;MultiplyNumbers()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;finalresult&nbsp;=&nbsp;(Convert.ToDouble(num1)&nbsp;*&nbsp;Convert.ToDouble(num2)).ToString();&nbsp;
}&nbsp;
&nbsp;
void&nbsp;DivideNumbers()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(Convert.ToDouble(num2)&nbsp;!=&nbsp;0)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;finalresult&nbsp;=&nbsp;(Convert.ToDouble(num1)&nbsp;/&nbsp;Convert.ToDouble(num2)).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;finalresult&nbsp;=&nbsp;&quot;Cannot&nbsp;Divide&nbsp;by&nbsp;Zero&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Let&rsquo;s understand this code. On the top, we are defining the route of this page using @page directive. So in this application, if we append &ldquo;/calculator&rdquo; to base URL then we will be redirected to this page.</span></p>
<p><span style="font-size:small">Then we have defined the HTML section to read two numbers from the user and display the result in another textbox. The attribute &ldquo;bind&rdquo; is used to bind the value entered in the textbox to the variables we have defined.
 We also created four buttons to perform our basic arithmetic operations. We are calling our business logic methods on button click.</span></p>
<div><span style="font-size:small">At the bottom of the page, we have a @functions section which contains all our business logic. We have declared three variables, two to read the value from the user and another one to display the result. We have also defined
 four methods to handle addition, subtraction, multiplication, and division. The &ldquo;bind&rdquo; attribute will work only for string variables not for floating point values. Hence, we need to convert a string to double to perform our arithmetic operations.</span><br>
<br>
<span style="font-size:small">Finally, we will add the link to our &ldquo;calculator&rdquo; page in the navigation menu, open /<em>Shared/NavMenu.cshtml</em>&nbsp;page and put the following code into it.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;top-row&nbsp;pl-4&nbsp;navbar&nbsp;navbar-dark&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;navbar-brand&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/&quot;</span><span class="html__tag_start">&gt;</span>BlazorTest<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;navbar-toggler&quot;</span>&nbsp;onclick=@ToggleNavMenu<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;navbar-toggler-icon&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;class=@(collapseNavMenu&nbsp;?&nbsp;&quot;collapse&quot;&nbsp;:&nbsp;null)&nbsp;onclick=@ToggleNavMenu<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ul</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav&nbsp;flex-column&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-item&nbsp;px-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;NavLink</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-link&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/&quot;</span>&nbsp;Match=NavLinkMatch.All<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;oi&nbsp;oi-home&quot;</span>&nbsp;<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Home&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/NavLink&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-item&nbsp;px-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;NavLink</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-link&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/counter&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;oi&nbsp;oi-plus&quot;</span>&nbsp;<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Counter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/NavLink&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-item&nbsp;px-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;NavLink</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-link&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/fetchdata&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;oi&nbsp;oi-list-rich&quot;</span>&nbsp;<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Fetch&nbsp;data&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/NavLink&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-item&nbsp;px-3&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;NavLink</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;nav-link&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/calculator&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">lass</span>=<span class="html__attr_value">&quot;oi&nbsp;oi-list-rich&quot;</span>&nbsp;<span class="html__attr_name">aria-hidden</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;Calculator&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/NavLink&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/ul&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
@functions&nbsp;{&nbsp;
bool&nbsp;collapseNavMenu&nbsp;=&nbsp;true;&nbsp;
&nbsp;
void&nbsp;ToggleNavMenu()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;collapseNavMenu&nbsp;=&nbsp;!collapseNavMenu;&nbsp;
}&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Congrats! We have created our first application using ASP.NET Core and Blazor. Let's execute the code and see the output.</span></p>
<div>
<h1>Execution Demo&nbsp;</h1>
</div>
<div><span style="font-size:small">Launch the application. You can see a &ldquo;Calculator&rdquo; link in the navigation menu on the left. Click on it to navigate to our&nbsp;<em>calculator</em>&nbsp;page. Notice the URL, it has&nbsp;<em>/calculator</em>&nbsp;appended
 to it.</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div></div>
<div><span style="font-size:small"><img id="199336" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199336/1/calcdemo.png" alt="" width="650" height="291"><br>
</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div><span style="font-size:small">Let's perform add operation. Input two numbers and click on&nbsp;<em>Add(&#43;)</em>&nbsp;button. You can see the addition result in the&nbsp;<em>Result</em>&nbsp;textbox.</span></div>
<div><span style="font-size:small"><br>
</span></div>
<div></div>
<div><span style="font-size:small"><img id="199337" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199337/1/addnumbers.png" alt="" width="650" height="295"><br>
</span></div>
<p>&nbsp;</p>
<p><span style="font-size:small">Now try to perform division on two numbers. You can get the result in Result textbox. If you try to perform division by Zero, you will get an error message &quot;Cannot Divide by Zero&quot;.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><img id="199338" src="https://i1.code.msdn.s-msft.com/aspnet-core-getting-7039bf70/image/file/199338/1/divide.png" alt="" width="650" height="295"></p>
<p><span style="font-size:small"><img id="197291" src="197291-divide.png" alt=""><br>
</span></p>
<p><span style="font-size:small">Similarly, try other operations and see the result.</span></p>
<h1>Conclusion</h1>
<p><span style="font-size:small">We learned about the new .NET framework &ndash; Blazor. We have also created a simple calculator application using Blazor and performed arithmetic operations on it. Please refer to the&nbsp;attached source code for better understanding.</span></p>
<h1><span>See Also</span></h1>
<ul>
<li><span style="font-size:small"><a rel="noopener" href="http://ankitsharmablogs.com/asp-net-core-crud-using-angular-5-and-entity-framework-core/" target="_blank">ASP.NET Core &ndash; CRUD Using Angular 5 And Entity Framework Core</a></span>
</li></ul>
<ul>
<li><span style="font-size:small"><a rel="noopener" href="http://ankitsharmablogs.com/crud-operations-asp-net-core-using-angular-5-ado-net/" target="_blank">CRUD Operations With ASP.NET Core Using Angular 5 and ADO.NET</a></span>
</li></ul>
<ul>
<li><span style="font-size:small"><a rel="noopener" href="http://ankitsharmablogs.com/getting-started-with-angular-5-using-visual-studio-code/" target="_blank">Getting Started With Angular 5 Using Visual Studio Code</a></span>
</li></ul>
<ul>
<li><span style="font-size:small"><a rel="noopener" href="http://ankitsharmablogs.com/crud-operation-asp-net-core-mvc-using-visual-studio-code-ef/" target="_blank">CRUD Operation With ASP.NET Core MVC Using Visual Studio Code and EF</a></span>
</li></ul>
<ul>
<li><span style="font-size:small"><a rel="noopener" href="http://ankitsharmablogs.com/crud-operation-with-asp-net-core-mvc-using-ado-net/" target="_blank">CRUD Operation With ASP.NET Core MVC Using ADO.NET and Visual Studio 2017</a></span>
</li></ul>
