# ASP.NET Document Viewer – Display PDF, Word, Excel & 50+ Other Types of Document
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- ASP.NET
- ASP.NET MVC
- ASP.NET Web Forms
- HTML5
## Topics
- Excel
- PowerPoint
- Word
- Visio
- Portable Document Format (pdf)
- asp.net document viewer
- display documents
## Updated
- 09/16/2015
## Description

<h2>Introduction</h2>
<p><span style="font-size:small">All web-based document viewers designed as a middleware for displaying documents inside a browser can be conditionally divided into two groups:
<strong>client middleware</strong> and <strong>client-server middleware</strong>.</span></p>
<p><span style="font-size:small">Viewers from the first group (client middleware) perform document visualization on the client PC: they download documents from the server to the client-side and then display them in a browser. This group of document viewers
 are built using either a Java applet, Adobe Flash, Microsoft Silverlight or similar client-side technologies. This group has two main drawbacks:</span></p>
<p><span style="font-size:small">1) The original document has to be downloaded to the client (which is potentially a significant security issue for your content).</span></p>
<p><span style="font-size:small">2) 3rd party software has to be installed on the client side (e.g. browser plugins).</span></p>
<p><span style="font-size:small">Document viewers from the second group (client-server) don&rsquo;t have these drawbacks. They convert the original document to a set of HTML code, images, SVG, CSS and JavaScript on the server-side and then transmit this data
 to the client-side. As a result, end-users see the document in a browser as an ordinary HTML web-page. There is no need to install any third-party browser plugins.</span></p>
<p><span style="font-size:small"><a href="http://groupdocs.com/dot-net/document-viewer-library" target="_blank">GroupDocs.Viewer for .NET</a> is a document viewer that belongs to this second group. It can be integrated into any website to display 50&#43; document
 types (including PDF and Microsoft Office), viewable on any web-enabled device. If a device has a web-browser that supports HTML, then it can properly display documents rendered by GroupDocs.Viewer.</span></p>
<p><span style="font-size:small">In order to achieve maximum performance on the client-side, by default, GroupDocs.Viewer doesn&rsquo;t send all the document&rsquo;s content to the browser when the document is opened. Thanks to support for streaming, the viewer
 asynchronously transmits only those pages and parts of the document that are requested by the client. Of course, this behavior can be adjusted or changed using various options.</span></p>
<h2>Requirements</h2>
<p><span style="font-size:small"><strong>Before you proceed</strong>, please note that this sample is built based on the commercial library &ndash;
<a href="http://groupdocs.com/dot-net/document-viewer-library">GroupDocs.Viewer for .NET</a>. In order to use the sample, please download a free evaluation copy of the library from
<a href="http://groupdocs.com/Community/files/8/.net-libraries/groupdocs_viewer_for_.net/entry8418.aspx">
this page</a>. Also, if you&rsquo;d like to test the viewer without any evaluation restrictions, please
<a rel="nofollow" href="http://groupdocs.com/corporate/contact-us">contact GroupDocs support</a> for a
<strong>free 30-day license</strong>.</span></p>
<p><span style="font-size:small">As already mentioned, the only requirement for the client-side is a web-browser that supports HTML, CSS and JavaScript. These could be IE, Chrome, FireFox, Safari, Opera and their mobile versions.</span></p>
<p><span style="font-size:small">Server-side is a bit more complicated. As the name suggests, GroupDocs.Viewer for .NET is a .NET assembly, meaning it requires a
<strong>.NET Framework version 4.0</strong> or higher. It also requires <strong>ASP.NET WebForms</strong> or
<strong>ASP.NET MVC version 3</strong> or higher.</span></p>
<p><span style="font-size:small">Because of its .NET nature, GroupDocs.Viewer requires a &ldquo;.NET-compatible&rdquo; web-server:
<strong>IIS</strong>, <strong>IIS Express</strong> or <strong>ASP.NET Development Server (Cassini)</strong>.</span></p>
<p><span style="font-size:small">And what about hardware requirements? GroupDocs.Viewer doesn&rsquo;t have any. If a machine is able to run ASP.NET web-sites on the IIS, then it is also able to run the viewer. However, displaying large documents is a quite
 heavy computational task that requires a fast CPU and a lot of memory. So the document rendering speed depends on the hardware specification of the server.</span></p>
<h2>Running the sample</h2>
<p><span style="font-size:small">Nothing beats seeing it with your own eyes. Before starting with the project, please download the GroupDocs.Viewer for .NET library from
<a href="http://groupdocs.com/Community/files/8/.net-libraries/groupdocs_viewer_for_.net/entry8418.aspx">
this page</a>. Then download and open this sample in Microsoft Visual Studio 2012 or higher. The sample contains a single project. Place the downloaded GroupDocs.Viewer for .NET library (GroupDocs.Viewer.dll) into the &ldquo;GroupDocsViewerWebFormsSample\libs&rdquo;
 folder. Now, compile and run the project. Once this is done, you will see a start page (Default.aspx) with a set of documents in your browser.</span></p>
<p><span style="font-size:small">The sample project contains a sort of a fake repository (the
<em>FileRepository</em> class) that returns a list of all available documents. In fact, it simply browses an &ldquo;<em>App_Data</em>&rdquo; folder and returns all files located there. You can see these files on the main page. &ldquo;<em>App_Data</em>&rdquo;
 already contains two sample files - &ldquo;<em>candy.pdf</em>&rdquo; and &ldquo;<em>Sample_2SpreadSheet.xlsx</em>&rdquo;. You can add your own files there - they will be listed on the main page after it's reloaded.</span></p>
<p><span style="font-size:small"><img id="128513" src="128513-main_page.png" alt="A list of available documents" width="734" height="257"></span></p>
<p><span style="font-size:small">When the <strong>Open</strong> link is clicked, a new web-page is opened with the GroupDocs.Viewer widget inside. On the screenshot below you can see the document &ldquo;<em>candy.pdf</em>&rdquo; opened in the HTML-based mode.</span></p>
<p><span style="font-size:small"><img id="128514" src="128514-viewer_page.png" alt="ASP.NET document viewer - Sample document" width="734" height="726"></span></p>
<p><span style="font-size:small">Now it&rsquo;s time to discover the difference between the image-based and HTML-based document rendering modes.</span></p>
<h2>Rendering modes in GroupDocs.Viewer for .NET</h2>
<p><span style="font-size:small">One of the most important and powerful features in GroupDocs.Viewer is the ability to display documents in two different rendering modes -
<strong>image-based</strong> and <strong>HTML-based</strong>. Each of these modes has its own advantages and disadvantages, and can be used depending on your preferences.</span></p>
<p><span style="font-size:small">The image-based document rendering mode, which was presented in GroupDocs.Viewer from the very first version, rasterizes each document page into an image and sends this to the client. If the original document has a text layer,
 the viewer parses the text saving its exact coordinates and then sends it to the client-side as well. Each chunk of text is placed on the page image using the coordinates. This mode renders the original document with 100% fidelity, but has the following drawbacks:</span></p>
<ul>
</ul>
<ul>
<li><span style="font-size:small">First of all, the textual layer is placed over the image using client-side JavaScript and thus it is not perceived as a native text by the browser. Of course, end users can still select and copy text to the clipboard, but browser-based
 search tools (Ctrl&#43;F) won't work. To deal with this issue, GroupDocs.Viewer has an in-built search panel that can be used to search for text within the document using keywords.</span>
</li></ul>
<ul>
<li><span style="font-size:small">Secondly, the image-based mode presents pages as images. But what if the original document has no pages at all? For example, a plain large Microsoft Excel sheet, Outlook message, TXT, CSV, HTML files or AutoCAD drawings, etc.
 In this case the viewer splits such documents into pages forcibly, which can make it hard for end users to read through and review the entire document.</span>
</li></ul>
<ul>
<li><span style="font-size:small">Finally, the image-based mode may be heavy in terms of memory and bandwidth requirements. If a document is quite large and has lots of pages, the viewer may require a lot of RAM and disk space to store and render rasterized
 pages.</span> </li></ul>
<p><span style="font-size:small">Due to these disadvantages, a new HTML-based mode was introduced in GroupDocs.Viewer 2.0. In this mode, the original document is converted to native HTML markup on the client-side. As a result, end users can leverage most of
 the browser features when viewing documents, such as native text search, copy/paste, and so on.</span></p>
<p><span style="font-size:small">Naturally, documents converted to HTML are much smaller than the same documents rasterized to images. The document layout is represented as lightweight scalable SVG vector graphics as opposed to heavy raster images. Unfortunately,
 some older browsers (for example Internet Explorer 8 and earlier) don&rsquo;t support SVG. In order to deal with this issue, GroupDocs.Viewer has an option to replace all SVG graphics with PNG images.</span></p>
<p><span style="font-size:small">To illustrate the difference between the two document rendering modes, please see the screenshots below. These are the same document - &ldquo;<em>Sample_2SpreadSheet.xlsx</em>&rdquo; - you can find it in the &ldquo;<em>App_Data</em>&rdquo;
 folder. Note that the Excel file has two sheets.</span></p>
<p><span style="font-size:small"><img id="128519" src="128519-viewer_image.png" alt="Image-based document rendering mode" width="734" height="726"></span></p>
<p><span style="font-size:small">On the screenshot above, the example Excel document is displayed in the image-based mode. It is split into a set of pages. Please note that the content from both sheets is placed one after another, sequentially.</span></p>
<p><span style="font-size:small"><img id="129520" src="129520-viewer-excel.png" alt="HTML-based document rendering mode" width="734" height="726"><br>
</span></p>
<p><span style="font-size:small">The same XLSX document, but rendered in the HTML-based mode. As you can see, the document is not split into several pages, but displayed as is. Also please note a tabbed navigation bar appeared in the bottom of the document,
 allowing users to switch between the sheets.</span></p>
<h2>Project overview</h2>
<p><span style="font-size:small">This section contains a brief overview of the sample itself. As mentioned above, it is a simple ASP.NET WebForms project that uses .NET Framework 4.0.</span></p>
<p><span style="font-size:small">GroupDocs.Viewer sends a lot of asynchronous requests to stream documents from the server. In the
<em>web.config</em> file you'll find all the necessary HTTP-handlers. If you are using ASP.NET MVC, there is no need to specify all these HTTP-handlers - you can simply invoke the
<em>Groupdocs.Web.UI.Viewer.InitRoutes()</em> method that does the same thing.</span></p>
<p><span style="font-size:small">In the <em>Application_Start</em> method in the <em>
Global.asax</em> file, a root storage path is specified. This is absolutely necessary for the GroupDocs.Viewer. You can also set a log file path and specify a license file if you have one. Without the license GroupDocs.Viewer operates in a trial mode.</span></p>
<p><span style="font-size:small">The <em>FileRepository</em> class returns a list of all files located in the &ldquo;<em>App_Data</em>&rdquo; folder. If you&rsquo;ll upload your own files there, the
<em>FileRepository</em> class returns them too.</span></p>
<p><span style="font-size:small">The <em>Default.aspx</em> page, as described before, simply displays a list of all documents and allows you to view them. The
<em>Viewer.aspx</em> page is the most interesting, as it contains the GroupDocs.Viewer widget on the code-front.</span></p>
<p><span style="font-size:small">In the <em>HEAD</em> block, there is an inclusion of all the necessary JavaScript/CSS libraries and scripts.</span></p>
<p><span style="font-size:small">The GroupDocs.Viewer widget (<em>&lt;%= Viewer.ClientCode().TargetElementSelector(&quot;#viewer&quot;)&hellip;</em>) is located in the
<em>BODY</em> block. When the web-page is rendered, this widget is transformed to JavaScript code, which invokes GroupDocs.Viewer, creates a viewport and fills it with the document&rsquo;s content.</span></p>
<p><span style="font-size:small">Finally, at the end of the page there is a JS code responsible for the dynamic resizing of the GroupDocs.Viewer viewport.</span></p>
<h2>Final notes</h2>
<p><span style="font-size:small">This sample project gives you a basic idea of how GroupDocs.Viewer for .NET can be used to build an ASP.NET document viewer capable of displaying all common business document formats. In fact, GroupDocs.Viewer has much more
 comprehensive functionality which allows you to seamlessly integrate it into projects of any complexity.</span></p>
<p><span style="font-size:small">For more details on the viewer and to download a free trial, please visit the product&rsquo;s official webpage at:
</span><br class="atl-forced-newline">
<span style="font-size:small"><a href="http://groupdocs.com/dot-net/document-viewer-library" target="_blank">http://groupdocs.com/dot-net/document-viewer-library</a></span></p>
<p><span style="font-size:small">Thank you for your attention!</span></p>
