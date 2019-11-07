# Convert 32 bit PNGs to high quality 8 bit PNGs
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- GDI+
## Topics
- Images
- Color Quantization
- Image Optimization
## Updated
- 09/11/2011
## Description

<p><strong>UPDATE</strong>: I have released a more productionized version of this quantizer at
<a href="http://nquant.codeplex.com/">nquant.codeplex.com</a>. There you will find documentation on the propper use of the quantizer. You can also integrate this directly into your own Visual Studio project using
<a href="http://nuget.org/">Nuget </a>by entering&nbsp;Install-Package nQuant in the&nbsp;Package Manager Console.</p>
<p>I&rsquo;ve been working on a C# HTTPModule called <a href="http://www.requestreduce.com/">
RequestReduce</a> that sprites CSS background images on the fly as well as merges and Minifes all CSS resources in the document head. For those who may not know, image spriting is a technique that takes individual images in separate image files and merges them
 into a single file. By tracking the offsets of where each image begins, you can use CSS syntax to limit a css background image to just one of the images in the file like so:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>
<pre class="hidden">background: url(/RequestReduceContent/94b703a23cf3a2644577ab68fa465844-e2d1ced7efd8cd883516e2da4e51a9d5.png) -241 0 no-repeat</pre>
<div class="preview">
<pre class="css"><span class="css__element">background</span>:&nbsp;<span class="css__url">url(</span>/RequestReduceContent/94b703a23cf3a2644577ab68fa465844-e2d1ced7efd8cd883516e2da4e51a9d5.png<span class="css__url">)</span>&nbsp;-<span class="css__element">241</span><span class="css__element">0</span><span class="css__element">no</span>-<span class="css__element">repeat</span></pre>
</div>
</div>
</div>
<p>By using this technique effectively, page load times will be faster since there will be fewer HTTP connections opened.</p>
<p>One of the items on my backlog has been image optimization. I had envisioned a feature that would either shell out to one of the popular PNG compressors or allow users a means of plugging in a compressor of their choice. About a week or two before releasing
 this project at work where I work on the Microsoft EPX Galleries team where we produce among many other galleries, the Visual Studio Gallery and the MSDN Code Samples Gallery, I was in a meeting discussing image optimization and someone was demonstrating the
 benefits of optimizing some of the images that get published in the MSDN dev centers. The impact on size was enormous and on the level of producing images several times smaller than their unoptimized originals.</p>
<p>So I figured how difficult could it be to add this feature to RequestReduce? My plan was to shell out to optipng.exe - a very popular and effective C Library that losslessly compresses PNG images. The answer was not difficult at all and the code looked something
 like this:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private void InvokeExecutable(string arguments, string executable)
        {
            using(var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    FileName = executable,
                    Arguments = arguments
                };
                process.Start();
                process.StandardOutput.ReadToEnd();
                process.WaitForExit(10000);
                if(!process.HasExited)
                {
                    process.Kill();
                    throw new OptimizationException
                        (string.Format(&quot;Unable to optimize image using executable {0} with arguments {1}&quot;, 
                        executable, arguments));
                }
            }
        }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;InvokeExecutable(<span class="cs__keyword">string</span>&nbsp;arguments,&nbsp;<span class="cs__keyword">string</span>&nbsp;executable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>(var&nbsp;process&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Process())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;process.StartInfo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ProcessStartInfo()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UseShellExecute&nbsp;=&nbsp;<span class="cs__keyword">false</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RedirectStandardOutput&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateNoWindow&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileName&nbsp;=&nbsp;executable,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Arguments&nbsp;=&nbsp;arguments&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;process.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;process.StandardOutput.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;process.WaitForExit(<span class="cs__number">10000</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(!process.HasExited)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;process.Kill();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span><span class="cs__keyword">new</span>&nbsp;OptimizationException&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Unable&nbsp;to&nbsp;optimize&nbsp;image&nbsp;using&nbsp;executable&nbsp;{0}&nbsp;with&nbsp;arguments&nbsp;{1}&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;executable,&nbsp;arguments));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>However, I was seeing image size reductions that were much less dramatic than the ones demoed in the meeting I attended. The reason was that I work with Web Devs who are typically good about optimizing images and the presenter in the meeting was referring
 to &ldquo;site managers&rdquo; who might know little to nothing about image optimization and sometimes upload huge images unaware of the consequences.</p>
<p>So I was a bit disappointed but decided to move forward with the feature. I was after all seeing some improvement but more on the order of 5%.</p>
<p>A couple days later I plugged RequestReduce into this blog. While it was very effective in reducing the number of HTTP requests, it appeared as though the total count of downloaded bytes was greater that before implementing RequestReduce. How could this
 be? With the minification of the CSS, it would certainly be less right? Apparently not. The main culprit was a JPG image that was originally abut 5k and was consuming well over this amount in my sprite.I figured this was a flaw I had to fix and I knew very
 little about the details of image optimization.</p>
<p>My first inclination was that I was creating the image incorrectly. I assumed there was some encoder setting I was failing to set correctly that was forcing the generation of 32 bit PNGs. I spent hours googling only to find there were countless others with
 the same inclination and no solution. Previously I had reviewed the code written for the
<a href="http://aspnet.codeplex.com/releases/view/65787">Asp.Net Sprite Framework</a>. This framework does something similar to RequestReduce but takes a very different approach that requires some intentional organization of the local image files before it
 can work. It had code, and eventually I had code that looked like this when finally generating the final PNG bitmap:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public byte[] GetBytes(string mimeType)
        {
            using (var spriteEncoderParameters = new EncoderParameters(1))
            {
                spriteEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 90);
                using (var stream = new MemoryStream())
                {
                    SpriteImage.Save(stream, ImageCodecInfo.GetImageEncoders().First(x =&gt; x.MimeType == mimeType), spriteEncoderParameters);
                    return stream.GetBuffer();
                }
            }
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">byte</span>[]&nbsp;GetBytes(<span class="cs__keyword">string</span>&nbsp;mimeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;spriteEncoderParameters&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameters(<span class="cs__number">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;spriteEncoderParameters.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(Encoder.Quality,&nbsp;<span class="cs__number">90</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;stream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SpriteImage.Save(stream,&nbsp;ImageCodecInfo.GetImageEncoders().First(x&nbsp;=&gt;&nbsp;x.MimeType&nbsp;==&nbsp;mimeType),&nbsp;spriteEncoderParameters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;stream.GetBuffer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div id="codeSnippetWrapper">Let me just set the record straight here because there are oodles of forum posts and stackoverflow answers concerning this and many give wrong or misleading answers.
<em>The Encoder.Quality parameter does absolutely nothing in the default PNG encoder as well as most of the other encoder parameters.
</em>I had thought that this was where the bulk of my problem lied. It wasn&rsquo;t.</div>
<p>Eventually it became clear that this was not going to be solved by some hidden property in the GDI&#43; api which is the API exposed in .net BCL for image manipulation. I stumbled upon a concept called image quantization. The process of reducing the number of
 colors in an image. This is a key concept in getting a 32 bit PNG to convert to a 8 bit PNG because an 8 bit PNG can have no more than 256 colors. It has what is called an Indexed Color palette. A part of the PNG file structure holds pointers to 256 colors
 and then each pixel in the image gets its color from one of those pointers. Thus each pixel only consumes one bytem its 0-255 value pointing to its color on the palette. On the other hand, a 32 bit PNG is 4 bytes per pixel and each pixel can represent a different
 ARGB color value. A 32 bit PNG also has a lot of wasted space since in may have multiple pixels that use the same color but they each hold their own copy.</p>
<p>So with this information it makes sense why my sprites had to be 32 bit PNGs. As I added images to the sprites, even if the individual images being added were 8 bit PNGs, I would inevitably accrue more than 256 colors, once that happens, an 8 bit PNG can
 no longer be used without some data loss. That said, data loss does not necessarily need to translate to &ldquo;perceptible&rdquo; quality loss. This is where color quantizers come into play.</p>
<p>Typically image optimization for the web takes one to two paths of optimization: lossless and lossy. Lossless guaeantees no quality loss and implements various compression strategies to shrink the size of a PNG. Popular tools like
<a href="http://optipng.sourceforge.net/">Optipng</a> or <a href="http://pmt.sourceforge.net/pngcrush/">
PngCrush</a> utilize this method, The savings can sometimes be significant and other times not so much. However, the savings is always &ldquo;free&rdquo; of quality loss and is therefore highly advisable.</p>
<p>Lossy compression does certainly run the risk of unacceptable quality loss but can often render images that are dramatically smaller than their 32 bit cousins and their quality loss is practically imperceptible. There is inevitably loss, but if the loss
 can either not be perceived at all or is so slight that the savings far outweigh the color loss, taking on the loss may be advisable. Often the deciding factor is the number of colors in the original image, The closer that number is to 256, the less quality
 loss there will be and therefore the less likely that any of this loss will be perceptible. RequestReduce&rsquo;s default color limit to quantize is 5000. However, this rule is not concrete. There are images where noticable color loss may occur beyond 3000
 colors and other times (especially dealing with photos, where 10000 images is fine to quantize.</p>
<p>So I only managed to find one open source .net based library that provided quantization and I was not comfortable with its license. There are a couple of C based EXEs that perform fast and effective quantization. The ones I used were
<a href="http://www.libpng.org/pub/png/apps/pngquant.html">PNGQuant</a> and <a href="http://pngnq.sourceforge.net/">
Pngnq</a>. The difference is the algorithm they employ for the quantization. I found that these produced decent quality images but one of my images (a rating star) was always off color. and a couple sprites had images with gradients that did look rather awful
 after the quantization. I eventially tried tweaking my code to limit the number of colors stored in a single sprite. This meant producing up to 3 sprite images for a page which seemed to me to be compromising the benefit of the sprite.</p>
<p>So I looked further into other quantization algorithms. I found an <a href="http://msdn.microsoft.com/en-us/library/aa479306.aspx">
old sample</a> on MSDN that I also found in an older version of Paint.net source code. My images looked terrible using this sample. Then I stumbled upon
<a href="http://www.codeproject.com/KB/recipes/SimplePaletteQuantizer.aspx?display=Mobile">
this article</a> on Code Project. It was a C# library that contained several different quantization algorithms. They all looked quite subpar except for one: an
<a href="http://www.ece.mcmaster.ca/~xwu/cq.c">algorithm</a> developed by Xiaolin Wu. My images looked perfect. I could not notice any loss. Furthermore, their sizes were even smaller than the images generated by the C exe libraries. There was just one catch:
 the algorithm assumed RGB values pixels with no alpha opacity value. Now this Code Project sample included an &ldquo;alpha blending&rdquo; technique that made the transparency &ldquo;appear&rdquo; to be visible but you had to know what the background color
 is to blend the transparency with. RequestReduce works with sites that it has no idea what the background color is.</p>
<p>Thus began a three week journey to tweak Xiaolin Wu&rsquo;s algorithm to include the fourth alpha layer. Let me just preface this with the fact that I have no math or statistics background to speak of. Sadly, someone with such a background probably would
 have spent a lot less time on this.But it was literally almost all I could think of for three weeks. It was the type of problem that I constantly felt I was about to solve within an hour but each breakthrough simply exposed a new problem that became more complex
 than I anticipated as I got closer.Before really jumping in, I had thought that adding the fourth Alpha dimension to RGB would be rather trivial. Just look for lines like:</p>
<div id="codeSnippetWrapper">
<pre id="codeSnippet">halfDistance = halfRed * halfRed &#43; halfGreen * halfGreen &#43; halfBlue * halfBlue;</pre>
</div>
<p>and change it to:</p>
<div id="codeSnippetWrapper">
<pre id="codeSnippet">halfDistance = halfRed * halfRed &#43; halfGreen * halfGreen &#43; halfBlue * halfBlue &#43; halfAlpha * halfAlpha;</pre>
</div>
<p>I can do that and a lot of it was just that. Except for a few key parts. I&rsquo;m not going to agonize the details of this discovery process. While perhaps theraputic to myself, it would have negative value for any reader. Suffice it to say that in the
 end after lots of scratch pads and notpad.exe windows full of random numbers and sequences, I eventually had a quantized image with 256 colors that looked really good, better and smaller than the ones produced by pngquant or pngnq. However they were not perfect.</p>
<p>As one can assume, adding an extra byte for alpha will translate to a source image .with potentially much more colors than a fully opaque image. This is because, technically, the same color with a different alpha value, is a different value and competes
 for one of the 256 slots in the 8 bit PNG indexed palette. In fact, there is the potential for 256x more colors. So I was not surprised to find that these quantized images were of slightly lower quality that the ones produced by the RGB quantizer.</p>
<p>Fortunately, in reality, the number of values used in the alpha channel are usually far less than those used in the RGB channels.That being the case, I took some liberties with the alpha values that increased the image quality while sacrificing the number
 of unique alpha values used. I used two strategies here:</p>
<p>1. I created an AlphaThreshold value. This is a constant that I set but should be configurable if this were production code. Any alpha value equal to or below the threshold gets translated to 0. I set this threshold to 30, finding that values with an alpha
 of 30 or less are for the most part invisible.</p>
<p>2. I normalized the source alpha values to their closest multiple of 70. Why 70? Because that is the number transmitted to me from the great master Astra who is the giver of justice in the curious singing forest. Gotta love Astra, A heart of gold that one..This
 essentially limits the number of values that the alpha channel can occupy but continues to allow for decent gradients. I&rsquo;m sure there are images where this would not work well but it looks good on all the images I have processed so far.</p>
<p>So lets dive into the code, You can find a complete working VS Solution on the MSDN Samples Gallery. The process of quantization can be split into the following parts:</p>
<ol>
<li>Read the unoptimized source image and create a histogram of its colors. Which colors are used and how often.
</li><li>Break down this data into several cumulative arrays that will make it much more efficient to slice and dice.
</li><li>Create 256 clusters of colors from which we will pick the resulting palette. This step is what sets Wu&rsquo;s algorithm apart from others. It is a process of perpetually splitting the color space into pairs of boxes to find clusters of colors with minimal
 variance. </li><li>Iterate over the source image again to find find the actual color closest to the mean of each cluster (these will be our palette colors) and map each pixel to its appropriate cluster.
</li><li>Generate the new quantized image from the data in step 4. </li></ol>
<p>Again, what lends to the accuracy of this algorithm is the clustering of colors of minimal variance. It is looking for the core colors in the image and not simply the colors most often used. With lower quality algorithms, it is far more likely for parts
 of an image to appear discolored as a more predominant color in the image. The color may be somewhat similar but quite noticeably different. From my tests, the Wu algorithm seems to eliminate these inaccuracies. For a deeper analysis from the author himself
 see <a href="http://books.google.com/books?id=tQn2pILgt9wC&source=gbs_similarbooks">
Graphics Gems vol. II</a>, pp. 126-133.</p>
<h2>Building the Histogram</h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static ColorData BuildHistogram(Bitmap sourceImage)
        {
            var data = sourceImage.LockBits(Rectangle.FromLTRB(0, 0, sourceImage.Width, sourceImage.Height),
                                            ImageLockMode.ReadOnly, sourceImage.PixelFormat);
            var colorData = new ColorData(MaxSideIndex);

            try
            {
                var byteLength = data.Stride &lt; 0 ? -data.Stride : data.Stride;
                var byteCount = Math.Max(1, BitDepth &gt;&gt; 3);
                var offset = 0;
                var buffer = new Byte[byteLength * sourceImage.Height];
                var value = new Byte[byteCount];

                Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
                for (var y = 0; y &lt; sourceImage.Height; y&#43;&#43;)
                {
                    var index = 0;
                    for (var x = 0; x &lt; sourceImage.Width; x&#43;&#43;)
                    {
                        var indexOffset = index &gt;&gt; 3;

                        for (var valueIndex = 0; valueIndex &lt; byteCount; valueIndex&#43;&#43;)
                            value[valueIndex] = buffer[offset &#43; valueIndex &#43; indexOffset];

                        var indexAlpha = (byte)((value[Alpha] &gt;&gt; 3) &#43; 1);
                        var indexRed = (byte)((value[Red] &gt;&gt; 3) &#43; 1);
                        var indexGreen = (byte)((value[Green] &gt;&gt; 3) &#43; 1);
                        var indexBlue = (byte)((value[Blue] &gt;&gt; 3) &#43; 1);

                        if (value[Alpha] &gt; AlphaThreshold)
                        {
                            if (value[Alpha] &lt; 255)
                            {
                                var alpha = value[Alpha] &#43; (value[Alpha] % 70);
                                value[Alpha] = (byte)(alpha &gt; 255 ? 255 : alpha);
                                indexAlpha = (byte)((value[Alpha] &gt;&gt; 3) &#43; 1);
                            }

                            colorData.Weights[indexAlpha, indexRed, indexGreen, indexBlue]&#43;&#43;;
                            colorData.MomentsRed[indexAlpha, indexRed, indexGreen, indexBlue] &#43;= value[Red];
                            colorData.MomentsGreen[indexAlpha, indexRed, indexGreen, indexBlue] &#43;= value[Green];
                            colorData.MomentsBlue[indexAlpha, indexRed, indexGreen, indexBlue] &#43;= value[Blue];
                            colorData.MomentsAlpha[indexAlpha, indexRed, indexGreen, indexBlue] &#43;= value[Alpha];
                            colorData.Moments[indexAlpha, indexRed, indexGreen, indexBlue] &#43;= (value[Alpha]*value[Alpha]) &#43;
                                                                                              (value[Red]*value[Red]) &#43;
                                                                                              (value[Green]*value[Green]) &#43;
                                                                                              (value[Blue]*value[Blue]);
                        }

                        colorData.QuantizedPixels.Add(BitConverter.ToInt32(new[] { indexAlpha, indexRed, indexGreen, indexBlue }, 0));
                        colorData.Pixels.Add(new Pixel(value[Alpha], value[Red], value[Green], value[Blue]));
                        index &#43;= BitDepth;
                    }
                    offset &#43;= byteLength;
                }
            }
            finally
            {
                sourceImage.UnlockBits(data);
            }
            return colorData;
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">static</span>&nbsp;ColorData&nbsp;BuildHistogram(Bitmap&nbsp;sourceImage)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;data&nbsp;=&nbsp;sourceImage.LockBits(Rectangle.FromLTRB(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;sourceImage.Width,&nbsp;sourceImage.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.ReadOnly,&nbsp;sourceImage.PixelFormat);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;colorData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColorData(MaxSideIndex);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;byteLength&nbsp;=&nbsp;data.Stride&nbsp;&lt;&nbsp;<span class="cs__number">0</span>&nbsp;?&nbsp;-data.Stride&nbsp;:&nbsp;data.Stride;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;byteCount&nbsp;=&nbsp;Math.Max(<span class="cs__number">1</span>,&nbsp;BitDepth&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;offset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Byte[byteLength&nbsp;*&nbsp;sourceImage.Height];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Byte[byteCount];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(data.Scan0,&nbsp;buffer,&nbsp;<span class="cs__number">0</span>,&nbsp;buffer.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;y&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;y&nbsp;&lt;&nbsp;sourceImage.Height;&nbsp;y&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;index&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;x&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;x&nbsp;&lt;&nbsp;sourceImage.Width;&nbsp;x&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;indexOffset&nbsp;=&nbsp;index&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;valueIndex&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;valueIndex&nbsp;&lt;&nbsp;byteCount;&nbsp;valueIndex&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">value</span>[valueIndex]&nbsp;=&nbsp;buffer[offset&nbsp;&#43;&nbsp;valueIndex&nbsp;&#43;&nbsp;indexOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;indexAlpha&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)((<span class="cs__keyword">value</span>[Alpha]&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;indexRed&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)((<span class="cs__keyword">value</span>[Red]&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;indexGreen&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)((<span class="cs__keyword">value</span>[Green]&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;indexBlue&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)((<span class="cs__keyword">value</span>[Blue]&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>[Alpha]&nbsp;&gt;&nbsp;AlphaThreshold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>[Alpha]&nbsp;&lt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;alpha&nbsp;=&nbsp;<span class="cs__keyword">value</span>[Alpha]&nbsp;&#43;&nbsp;(<span class="cs__keyword">value</span>[Alpha]&nbsp;%&nbsp;<span class="cs__number">70</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">value</span>[Alpha]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(alpha&nbsp;&gt;&nbsp;<span class="cs__number">255</span>&nbsp;?&nbsp;<span class="cs__number">255</span>&nbsp;:&nbsp;alpha);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indexAlpha&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)((<span class="cs__keyword">value</span>[Alpha]&nbsp;&gt;&gt;&nbsp;<span class="cs__number">3</span>)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.Weights[indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue]&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.MomentsRed[indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue]&nbsp;&#43;=&nbsp;<span class="cs__keyword">value</span>[Red];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.MomentsGreen[indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue]&nbsp;&#43;=&nbsp;<span class="cs__keyword">value</span>[Green];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.MomentsBlue[indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue]&nbsp;&#43;=&nbsp;<span class="cs__keyword">value</span>[Blue];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.MomentsAlpha[indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue]&nbsp;&#43;=&nbsp;<span class="cs__keyword">value</span>[Alpha];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.Moments[indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue]&nbsp;&#43;=&nbsp;(<span class="cs__keyword">value</span>[Alpha]*<span class="cs__keyword">value</span>[Alpha])&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="cs__keyword">value</span>[Red]*<span class="cs__keyword">value</span>[Red])&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="cs__keyword">value</span>[Green]*<span class="cs__keyword">value</span>[Green])&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="cs__keyword">value</span>[Blue]*<span class="cs__keyword">value</span>[Blue]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.QuantizedPixels.Add(BitConverter.ToInt32(<span class="cs__keyword">new</span>[]&nbsp;{&nbsp;indexAlpha,&nbsp;indexRed,&nbsp;indexGreen,&nbsp;indexBlue&nbsp;},&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorData.Pixels.Add(<span class="cs__keyword">new</span>&nbsp;Pixel(<span class="cs__keyword">value</span>[Alpha],&nbsp;<span class="cs__keyword">value</span>[Red],&nbsp;<span class="cs__keyword">value</span>[Green],&nbsp;<span class="cs__keyword">value</span>[Blue]));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;index&nbsp;&#43;=&nbsp;BitDepth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;offset&nbsp;&#43;=&nbsp;byteLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceImage.UnlockBits(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;colorData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div id="codeSnippetWrapper">This is rather straight forward with just two things to note. First, note that there are a few ways to iterate over the pixels of a bit map. Three that I can think of:</div>
<ol>
<li>The simplest but by far the most inefficient is to simply create a for loop for x and y and call GetPixel(x,y) which returns the color of that pixel.
</li><li>Use lockbits and unlock bits (as seen above) but with the difference of using pointers to iterate over the locked memory space of the image. This is much faster than technique number one but requires you to compile the code as unsafe.
</li><li>Use lockbits and unlock but use Marshal.Copy to feed the memory into a buffer.
</li></ol>
<p>Second, note that we drop the three rightmost bit of each color dimension.This reduces the granularity of the color maps produced in the next step, making it much faster, This allows us to create our clusters using color values from 1 to 32 instead of 256.</p>
<h2>Creating the Color Arrays</h2>
<p>These are the data structures that all of the upcoming analysis is performed upon. If this step is off, everything else will be off. This is one of the steps that really led me down a rat hole. For the longest time I thought this was correct and was looking
 for bugs elsewhere.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static ColorData CalculateMoments(ColorData data)
        {
            for (var alphaIndex = 1; alphaIndex &lt;= MaxSideIndex; &#43;&#43;alphaIndex)
            {
                var xarea = new long[SideSize, SideSize, SideSize];
                var xareaAlpha = new long[SideSize, SideSize, SideSize];
                var xareaRed = new long[SideSize, SideSize, SideSize];
                var xareaGreen = new long[SideSize, SideSize, SideSize];
                var xareaBlue = new long[SideSize, SideSize, SideSize];
                var xarea2 = new float[SideSize, SideSize, SideSize];
                for (var redIndex = 1; redIndex &lt;= MaxSideIndex; &#43;&#43;redIndex)
                {
                    var area = new long[SideSize];
                    var areaAlpha = new long[SideSize];
                    var areaRed = new long[SideSize];
                    var areaGreen = new long[SideSize];
                    var areaBlue = new long[SideSize];
                    var area2 = new float[SideSize];
                    for (var greenIndex = 1; greenIndex &lt;= MaxSideIndex; &#43;&#43;greenIndex)
                    {
                        long line = 0;
                        long lineAlpha = 0;
                        long lineRed = 0;
                        long lineGreen = 0;
                        long lineBlue = 0;
                        var line2 = 0.0f;
                        for (var blueIndex = 1; blueIndex &lt;= MaxSideIndex; &#43;&#43;blueIndex)
                        {
                            line &#43;= data.Weights[alphaIndex, redIndex, greenIndex, blueIndex];
                            lineAlpha &#43;= data.MomentsAlpha[alphaIndex, redIndex, greenIndex, blueIndex];
                            lineRed &#43;= data.MomentsRed[alphaIndex, redIndex, greenIndex, blueIndex];
                            lineGreen &#43;= data.MomentsGreen[alphaIndex, redIndex, greenIndex, blueIndex];
                            lineBlue &#43;= data.MomentsBlue[alphaIndex, redIndex, greenIndex, blueIndex];
                            line2 &#43;= data.Moments[alphaIndex, redIndex, greenIndex, blueIndex];

                            area[blueIndex] &#43;= line;
                            areaAlpha[blueIndex] &#43;= lineAlpha;
                            areaRed[blueIndex] &#43;= lineRed;
                            areaGreen[blueIndex] &#43;= lineGreen;
                            areaBlue[blueIndex] &#43;= lineBlue;
                            area2[blueIndex] &#43;= line2;

                            xarea[redIndex, greenIndex, blueIndex] = xarea[redIndex - 1, greenIndex, blueIndex] 
                            &#43; area[blueIndex];
                            xareaAlpha[redIndex, greenIndex, blueIndex] = 
                             xareaAlpha[redIndex - 1, greenIndex, blueIndex] 
                             &#43; areaAlpha[blueIndex];
                            xareaRed[redIndex, greenIndex, blueIndex] = 
                             xareaRed[redIndex - 1, greenIndex, blueIndex] 
                             &#43; areaRed[blueIndex];
                            xareaGreen[redIndex, greenIndex, blueIndex] = 
                            xareaGreen[redIndex - 1, greenIndex, blueIndex] 
                            &#43; areaGreen[blueIndex];
                            xareaBlue[redIndex, greenIndex, blueIndex] = 
                            xareaBlue[redIndex - 1, greenIndex, blueIndex] 
                            &#43; areaBlue[blueIndex];
                            xarea2[redIndex, greenIndex, blueIndex] = 
                            xarea2[redIndex - 1, greenIndex, blueIndex] 
                            &#43; area2[blueIndex];

                            data.Weights[alphaIndex, redIndex, greenIndex, blueIndex] = 
                             data.Weights[alphaIndex - 1, redIndex, greenIndex, blueIndex] 
                             &#43; xarea[redIndex, greenIndex, blueIndex];
                            data.MomentsAlpha[alphaIndex, redIndex, greenIndex, blueIndex] = 
                             data.MomentsAlpha[alphaIndex - 1, redIndex, greenIndex, blueIndex] 
                              &#43; xareaAlpha[redIndex, greenIndex, blueIndex];
                            data.MomentsRed[alphaIndex, redIndex, greenIndex, blueIndex] = 
                             data.MomentsRed[alphaIndex - 1, redIndex, greenIndex, blueIndex] 
                             &#43; xareaRed[redIndex, greenIndex, blueIndex];
                            data.MomentsGreen[alphaIndex, redIndex, greenIndex, blueIndex] = 
                            data.MomentsGreen[alphaIndex - 1, redIndex, greenIndex, blueIndex] 
                             &#43; xareaGreen[redIndex, greenIndex, blueIndex];
                            data.MomentsBlue[alphaIndex, redIndex, greenIndex, blueIndex] = 
                            data.MomentsBlue[alphaIndex - 1, redIndex, greenIndex, blueIndex] 
                            &#43; xareaBlue[redIndex, greenIndex, blueIndex];
                            data.Moments[alphaIndex, redIndex, greenIndex, blueIndex] = 
                             data.Moments[alphaIndex - 1, redIndex, greenIndex, blueIndex] 
                              &#43; xarea2[redIndex, greenIndex, blueIndex];
                        }
                    }
                }
            }
            return data;
        }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;ColorData&nbsp;CalculateMoments(ColorData&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;alphaIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;alphaIndex&nbsp;&lt;=&nbsp;MaxSideIndex;&nbsp;&#43;&#43;alphaIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xarea&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize,&nbsp;SideSize,&nbsp;SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xareaAlpha&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize,&nbsp;SideSize,&nbsp;SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xareaRed&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize,&nbsp;SideSize,&nbsp;SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xareaGreen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize,&nbsp;SideSize,&nbsp;SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xareaBlue&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize,&nbsp;SideSize,&nbsp;SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xarea2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[SideSize,&nbsp;SideSize,&nbsp;SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;redIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;redIndex&nbsp;&lt;=&nbsp;MaxSideIndex;&nbsp;&#43;&#43;redIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;area&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;areaAlpha&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;areaRed&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;areaGreen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;areaBlue&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">long</span>[SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;area2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[SideSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;greenIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;greenIndex&nbsp;&lt;=&nbsp;MaxSideIndex;&nbsp;&#43;&#43;greenIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;line&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;lineAlpha&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;lineRed&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;lineGreen&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;lineBlue&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;line2&nbsp;=&nbsp;<span class="cs__number">0</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;blueIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;blueIndex&nbsp;&lt;=&nbsp;MaxSideIndex;&nbsp;&#43;&#43;blueIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;line&nbsp;&#43;=&nbsp;data.Weights[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineAlpha&nbsp;&#43;=&nbsp;data.MomentsAlpha[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineRed&nbsp;&#43;=&nbsp;data.MomentsRed[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineGreen&nbsp;&#43;=&nbsp;data.MomentsGreen[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineBlue&nbsp;&#43;=&nbsp;data.MomentsBlue[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;line2&nbsp;&#43;=&nbsp;data.Moments[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;area[blueIndex]&nbsp;&#43;=&nbsp;line;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;areaAlpha[blueIndex]&nbsp;&#43;=&nbsp;lineAlpha;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;areaRed[blueIndex]&nbsp;&#43;=&nbsp;lineRed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;areaGreen[blueIndex]&nbsp;&#43;=&nbsp;lineGreen;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;areaBlue[blueIndex]&nbsp;&#43;=&nbsp;lineBlue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;area2[blueIndex]&nbsp;&#43;=&nbsp;line2;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xarea[redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;xarea[redIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;area[blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaAlpha[redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaAlpha[redIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;areaAlpha[blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaRed[redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaRed[redIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;areaRed[blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaGreen[redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaGreen[redIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;areaGreen[blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaBlue[redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xareaBlue[redIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;areaBlue[blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xarea2[redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xarea2[redIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;area2[blueIndex];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Weights[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Weights[alphaIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;xarea[redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsAlpha[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsAlpha[alphaIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;xareaAlpha[redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsRed[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsRed[alphaIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;xareaRed[redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsGreen[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsGreen[alphaIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;xareaGreen[redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsBlue[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.MomentsBlue[alphaIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;xareaBlue[redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Moments[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Moments[alphaIndex&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;xarea2[redIndex,&nbsp;greenIndex,&nbsp;blueIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div id="codeSnippetWrapper">the end you should have a set of multi dimensional arrays that cumulatively increase both vertically down each &ldquo;line&rdquo; (or most finely grained dimension &ndash; blue here) and across to the right from A to R to G to
 B. The very last value in the array should be the total sum of the original array.</div>
<div></div>
<div>Arranging the data n this way allows you to make very efficient measurements on regions of the color space from just a few calculations instead of having to iterate over every point.</div>
<div></div>
<h2>Clustering the Data</h2>
<p>There is a fair amount of code involved here so I will not include all of it. Here is the entry point into this step:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static IList&lt;Box&gt; SplitData(ref int colorCount, ColorData data)
        {
            --colorCount;
            var next = 0;
            var volumeVariance = new float[MaxColor];
            var cubes = new Box[MaxColor];
            cubes[0].AlphaMaximum = MaxSideIndex;
            cubes[0].RedMaximum = MaxSideIndex;
            cubes[0].GreenMaximum = MaxSideIndex;
            cubes[0].BlueMaximum = MaxSideIndex;
            for (var cubeIndex = 1; cubeIndex &lt; colorCount; &#43;&#43;cubeIndex)
            {
                if (Cut(data, ref cubes[next], ref cubes[cubeIndex]))
                {
                    volumeVariance[next] = cubes[next].Size &gt; 1 ? CalculateVariance(data, cubes[next]) : 0.0f;
                    volumeVariance[cubeIndex] = cubes[cubeIndex].Size &gt; 1 ? CalculateVariance(data, cubes[cubeIndex]) : 0.0f;
                }
                else
                {
                    volumeVariance[next] = 0.0f;
                    cubeIndex--;
                }

                next = 0;
                var temp = volumeVariance[0];

                for (var index = 1; index &lt;= cubeIndex; &#43;&#43;index)
                {
                    if (volumeVariance[index] &lt;= temp) continue;
                    temp = volumeVariance[index];
                    next = index;
                }

                if (temp &gt; 0.0) continue;
                colorCount = cubeIndex &#43; 1;
                break;
            }
            return cubes.Take(colorCount).ToList();
        }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IList&lt;Box&gt;&nbsp;SplitData(<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;colorCount,&nbsp;ColorData&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--colorCount;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;next&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;volumeVariance&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[MaxColor];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cubes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Box[MaxColor];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cubes[<span class="cs__number">0</span>].AlphaMaximum&nbsp;=&nbsp;MaxSideIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cubes[<span class="cs__number">0</span>].RedMaximum&nbsp;=&nbsp;MaxSideIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cubes[<span class="cs__number">0</span>].GreenMaximum&nbsp;=&nbsp;MaxSideIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cubes[<span class="cs__number">0</span>].BlueMaximum&nbsp;=&nbsp;MaxSideIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;cubeIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;cubeIndex&nbsp;&lt;&nbsp;colorCount;&nbsp;&#43;&#43;cubeIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Cut(data,&nbsp;<span class="cs__keyword">ref</span>&nbsp;cubes[next],&nbsp;<span class="cs__keyword">ref</span>&nbsp;cubes[cubeIndex]))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;volumeVariance[next]&nbsp;=&nbsp;cubes[next].Size&nbsp;&gt;&nbsp;<span class="cs__number">1</span>&nbsp;?&nbsp;CalculateVariance(data,&nbsp;cubes[next])&nbsp;:&nbsp;<span class="cs__number">0</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;volumeVariance[cubeIndex]&nbsp;=&nbsp;cubes[cubeIndex].Size&nbsp;&gt;&nbsp;<span class="cs__number">1</span>&nbsp;?&nbsp;CalculateVariance(data,&nbsp;cubes[cubeIndex])&nbsp;:&nbsp;<span class="cs__number">0</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;volumeVariance[next]&nbsp;=&nbsp;<span class="cs__number">0</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cubeIndex--;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;next&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;temp&nbsp;=&nbsp;volumeVariance[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;index&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;index&nbsp;&lt;=&nbsp;cubeIndex;&nbsp;&#43;&#43;index)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(volumeVariance[index]&nbsp;&lt;=&nbsp;temp)&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp&nbsp;=&nbsp;volumeVariance[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;next&nbsp;=&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(temp&nbsp;&gt;&nbsp;<span class="cs__number">0.0</span>)&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorCount&nbsp;=&nbsp;cubeIndex&nbsp;&#43;&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;cubes.Take(colorCount).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">To dive deeper into what is going on, follow the Cut method. Note that this is looking to build 256 clusters of the smallest possible variance. One interesting piece of code a bit deeper down that I would like to point out is the
 calculation to obtain the volume of each cube. This demonstrates how the cumulative array allows you to make this calculation without iterating each element in the array:</p>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static long Volume(Box cube, long[,,,] moment)
        {
            return (moment[cube.AlphaMaximum, cube.RedMaximum, cube.GreenMaximum, cube.BlueMaximum] -
                    moment[cube.AlphaMaximum, cube.RedMaximum, cube.GreenMinimum, cube.BlueMaximum] -
                    moment[cube.AlphaMaximum, cube.RedMinimum, cube.GreenMaximum, cube.BlueMaximum] &#43;
                    moment[cube.AlphaMaximum, cube.RedMinimum, cube.GreenMinimum, cube.BlueMaximum] -
                    moment[cube.AlphaMinimum, cube.RedMaximum, cube.GreenMaximum, cube.BlueMaximum] &#43;
                    moment[cube.AlphaMinimum, cube.RedMaximum, cube.GreenMinimum, cube.BlueMaximum] &#43;
                    moment[cube.AlphaMinimum, cube.RedMinimum, cube.GreenMaximum, cube.BlueMaximum] -
                    moment[cube.AlphaMinimum, cube.RedMinimum, cube.GreenMinimum, cube.BlueMaximum]) -

                    (moment[cube.AlphaMaximum, cube.RedMaximum, cube.GreenMaximum, cube.BlueMinimum] -
                    moment[cube.AlphaMinimum, cube.RedMaximum, cube.GreenMaximum, cube.BlueMinimum] -
                    moment[cube.AlphaMaximum, cube.RedMaximum, cube.GreenMinimum, cube.BlueMinimum] &#43;
                    moment[cube.AlphaMinimum, cube.RedMaximum, cube.GreenMinimum, cube.BlueMinimum] -
                    moment[cube.AlphaMaximum, cube.RedMinimum, cube.GreenMaximum, cube.BlueMinimum] &#43;
                    moment[cube.AlphaMinimum, cube.RedMinimum, cube.GreenMaximum, cube.BlueMinimum] &#43;
                    moment[cube.AlphaMaximum, cube.RedMinimum, cube.GreenMinimum, cube.BlueMinimum] -
                    moment[cube.AlphaMinimum, cube.RedMinimum, cube.GreenMinimum, cube.BlueMinimum]);
        }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">long</span>&nbsp;Volume(Box&nbsp;cube,&nbsp;<span class="cs__keyword">long</span>[,,,]&nbsp;moment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(moment[cube.AlphaMaximum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMaximum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMaximum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMaximum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMaximum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMaximum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMaximum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMaximum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMaximum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMaximum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMaximum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMaximum])&nbsp;-&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(moment[cube.AlphaMaximum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMinimum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMinimum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMaximum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMinimum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMaximum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMinimum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMaximum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMinimum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMinimum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMaximum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMinimum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.AlphaMinimum,&nbsp;cube.RedMinimum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMinimum]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Just 15 simple arithmetic operations instead of 32768. This is another formula that I agonized over for days. The trick is figuring out where to put the pluses and minuses. The original RGB method is:</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static Int64 Volume(WuColorCube cube, Int64[, ,] moment)
        {
            return moment[cube.RedMaximum, cube.GreenMaximum, cube.BlueMaximum] -
                   moment[cube.RedMaximum, cube.GreenMaximum, cube.BlueMinimum] -
                   moment[cube.RedMaximum, cube.GreenMinimum, cube.BlueMaximum] &#43;
                   moment[cube.RedMaximum, cube.GreenMinimum, cube.BlueMinimum] -
                   moment[cube.RedMinimum, cube.GreenMaximum, cube.BlueMaximum] &#43;
                   moment[cube.RedMinimum, cube.GreenMaximum, cube.BlueMinimum] &#43;
                   moment[cube.RedMinimum, cube.GreenMinimum, cube.BlueMaximum] -
                   moment[cube.RedMinimum, cube.GreenMinimum, cube.BlueMinimum];
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">static</span>&nbsp;Int64&nbsp;Volume(WuColorCube&nbsp;cube,&nbsp;Int64[,&nbsp;,]&nbsp;moment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;moment[cube.RedMaximum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMaximum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMaximum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMinimum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMaximum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMaximum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMaximum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMinimum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMinimum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMaximum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMinimum,&nbsp;cube.GreenMaximum,&nbsp;cube.BlueMinimum]&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMinimum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMaximum]&nbsp;-&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moment[cube.RedMinimum,&nbsp;cube.GreenMinimum,&nbsp;cube.BlueMinimum];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div id="codeSnippetWrapper">The similarity is obvious. The key is building the arrays correctly. With incorrect data, this formula will never come out right. I also did not expect the addition of alpha to require parentheses.</div>
<div></div>
<h2>Generating the Final Palette</h2>
<p>This builds the final data structure we need to create out quantized image:</p>
<h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static QuantizedPalette GetQuantizedPalette(int colorCount, ColorData data, IEnumerable&lt;Box&gt; cubes)
        {
            var imageSize = data.Pixels.Count;
            var lookups = BuildLookups(cubes, data);

            for(var index = 0; index &lt; imageSize; &#43;&#43;index)
            {
                var indexParts = BitConverter.GetBytes(data.QuantizedPixels[index]);
                data.QuantizedPixels[index] = lookups.Tags[indexParts[Alpha], indexParts[Red], indexParts[Green], indexParts[Blue]];
            }

            var alphas = new int[colorCount &#43; 1];
            var reds = new int[colorCount &#43; 1];
            var greens = new int[colorCount &#43; 1];
            var blues = new int[colorCount &#43; 1];
            var sums = new int[colorCount &#43; 1];
            var palette = new QuantizedPalette(imageSize);
            var index2 = -1;

            foreach (var pixel in data.Pixels)
            {
                palette.PixelIndex[&#43;&#43;index2] = -1;
                if(pixel.Alpha &lt;= AlphaThreshold)
                    continue;

                var match = data.QuantizedPixels[index2];
                var bestMatch = match;
                var bestDistance = 100000000;
                var index = -1;

                foreach (var lookup in lookups.Lookups)
                {
                    &#43;&#43;index;
                    var deltaAlpha = pixel.Alpha - lookup.Alpha;
                    var deltaRed = pixel.Red - lookup.Red;
                    var deltaGreen = pixel.Green - lookup.Green;
                    var deltaBlue = pixel.Blue - lookup.Blue;

                    var distance = deltaAlpha * deltaAlpha &#43; deltaRed * deltaRed &#43; deltaGreen * deltaGreen &#43; deltaBlue * deltaBlue;

                    if (distance &gt;= bestDistance) continue;

                    bestDistance = distance;
                    bestMatch = index;
                }
                
                alphas[bestMatch] &#43;= pixel.Alpha;
                reds[bestMatch] &#43;= pixel.Red;
                greens[bestMatch] &#43;= pixel.Green;
                blues[bestMatch] &#43;= pixel.Blue;
                sums[bestMatch]&#43;&#43;;

                palette.PixelIndex[index2] = bestMatch;
            }

            for (var paletteIndex = 0; paletteIndex &lt; colorCount; paletteIndex&#43;&#43;)
            {
                if (sums[paletteIndex] &gt; 0)
                {
                    alphas[paletteIndex] /= sums[paletteIndex];
                    reds[paletteIndex] /= sums[paletteIndex];
                    greens[paletteIndex] /= sums[paletteIndex];
                    blues[paletteIndex] /= sums[paletteIndex];
                }

                var color = Color.FromArgb(alphas[paletteIndex], reds[paletteIndex], greens[paletteIndex], blues[paletteIndex]);
                palette.Colors.Add(color);
            }
            palette.Colors.Add(Color.FromArgb(0, 0, 0, 0));

            return palette;
        }


        private static LookupData BuildLookups(IEnumerable&lt;Box&gt; cubes, ColorData data)
        {
            var lookups = new LookupData(SideSize);

            foreach (var cube in cubes)
            {
                for (var alphaIndex = (byte)(cube.AlphaMinimum &#43; 1); alphaIndex &lt;= cube.AlphaMaximum; &#43;&#43;alphaIndex)
                {
                    for (var redIndex = (byte)(cube.RedMinimum &#43; 1); redIndex &lt;= cube.RedMaximum; &#43;&#43;redIndex)
                    {
                        for (var greenIndex = (byte)(cube.GreenMinimum &#43; 1); greenIndex &lt;= cube.GreenMaximum; &#43;&#43;greenIndex)
                        {
                            for (var blueIndex = (byte)(cube.BlueMinimum &#43; 1); blueIndex &lt;= cube.BlueMaximum; &#43;&#43;blueIndex)
                                lookups.Tags[alphaIndex, redIndex, greenIndex, blueIndex] = lookups.Lookups.Count;
                        }
                    }
                }

                var weight = Volume(cube, data.Weights);

                if (weight &lt;= 0) continue;

                var lookup = new Lookup
                                 {
                                     Alpha = (int) (Volume(cube, data.MomentsAlpha)/weight),
                                     Red = (int) (Volume(cube, data.MomentsRed)/weight),
                                     Green = (int) (Volume(cube, data.MomentsGreen)/weight),
                                     Blue = (int) (Volume(cube, data.MomentsBlue)/weight)
                                 };
                lookups.Lookups.Add(lookup);
            }
            return lookups;
        }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;QuantizedPalette&nbsp;GetQuantizedPalette(<span class="cs__keyword">int</span>&nbsp;colorCount,&nbsp;ColorData&nbsp;data,&nbsp;IEnumerable&lt;Box&gt;&nbsp;cubes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;imageSize&nbsp;=&nbsp;data.Pixels.Count;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lookups&nbsp;=&nbsp;BuildLookups(cubes,&nbsp;data);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(var&nbsp;index&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;index&nbsp;&lt;&nbsp;imageSize;&nbsp;&#43;&#43;index)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;indexParts&nbsp;=&nbsp;BitConverter.GetBytes(data.QuantizedPixels[index]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.QuantizedPixels[index]&nbsp;=&nbsp;lookups.Tags[indexParts[Alpha],&nbsp;indexParts[Red],&nbsp;indexParts[Green],&nbsp;indexParts[Blue]];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;alphas&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[colorCount&nbsp;&#43;&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;reds&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[colorCount&nbsp;&#43;&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;greens&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[colorCount&nbsp;&#43;&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blues&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[colorCount&nbsp;&#43;&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sums&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[colorCount&nbsp;&#43;&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;palette&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QuantizedPalette(imageSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;index2&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;pixel&nbsp;<span class="cs__keyword">in</span>&nbsp;data.Pixels)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;palette.PixelIndex[&#43;&#43;index2]&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(pixel.Alpha&nbsp;&lt;=&nbsp;AlphaThreshold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;match&nbsp;=&nbsp;data.QuantizedPixels[index2];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bestMatch&nbsp;=&nbsp;match;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bestDistance&nbsp;=&nbsp;<span class="cs__number">100000000</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;index&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;lookup&nbsp;<span class="cs__keyword">in</span>&nbsp;lookups.Lookups)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&#43;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;deltaAlpha&nbsp;=&nbsp;pixel.Alpha&nbsp;-&nbsp;lookup.Alpha;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;deltaRed&nbsp;=&nbsp;pixel.Red&nbsp;-&nbsp;lookup.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;deltaGreen&nbsp;=&nbsp;pixel.Green&nbsp;-&nbsp;lookup.Green;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;deltaBlue&nbsp;=&nbsp;pixel.Blue&nbsp;-&nbsp;lookup.Blue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;distance&nbsp;=&nbsp;deltaAlpha&nbsp;*&nbsp;deltaAlpha&nbsp;&#43;&nbsp;deltaRed&nbsp;*&nbsp;deltaRed&nbsp;&#43;&nbsp;deltaGreen&nbsp;*&nbsp;deltaGreen&nbsp;&#43;&nbsp;deltaBlue&nbsp;*&nbsp;deltaBlue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(distance&nbsp;&gt;=&nbsp;bestDistance)&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bestDistance&nbsp;=&nbsp;distance;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bestMatch&nbsp;=&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alphas[bestMatch]&nbsp;&#43;=&nbsp;pixel.Alpha;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reds[bestMatch]&nbsp;&#43;=&nbsp;pixel.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greens[bestMatch]&nbsp;&#43;=&nbsp;pixel.Green;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blues[bestMatch]&nbsp;&#43;=&nbsp;pixel.Blue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sums[bestMatch]&#43;&#43;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;palette.PixelIndex[index2]&nbsp;=&nbsp;bestMatch;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;paletteIndex&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;paletteIndex&nbsp;&lt;&nbsp;colorCount;&nbsp;paletteIndex&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(sums[paletteIndex]&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alphas[paletteIndex]&nbsp;/=&nbsp;sums[paletteIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reds[paletteIndex]&nbsp;/=&nbsp;sums[paletteIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greens[paletteIndex]&nbsp;/=&nbsp;sums[paletteIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blues[paletteIndex]&nbsp;/=&nbsp;sums[paletteIndex];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;color&nbsp;=&nbsp;Color.FromArgb(alphas[paletteIndex],&nbsp;reds[paletteIndex],&nbsp;greens[paletteIndex],&nbsp;blues[paletteIndex]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;palette.Colors.Add(color);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;palette.Colors.Add(Color.FromArgb(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;palette;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;LookupData&nbsp;BuildLookups(IEnumerable&lt;Box&gt;&nbsp;cubes,&nbsp;ColorData&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lookups&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LookupData(SideSize);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;cube&nbsp;<span class="cs__keyword">in</span>&nbsp;cubes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;alphaIndex&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(cube.AlphaMinimum&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;alphaIndex&nbsp;&lt;=&nbsp;cube.AlphaMaximum;&nbsp;&#43;&#43;alphaIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;redIndex&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(cube.RedMinimum&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;redIndex&nbsp;&lt;=&nbsp;cube.RedMaximum;&nbsp;&#43;&#43;redIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;greenIndex&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(cube.GreenMinimum&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;greenIndex&nbsp;&lt;=&nbsp;cube.GreenMaximum;&nbsp;&#43;&#43;greenIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;blueIndex&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(cube.BlueMinimum&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;blueIndex&nbsp;&lt;=&nbsp;cube.BlueMaximum;&nbsp;&#43;&#43;blueIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lookups.Tags[alphaIndex,&nbsp;redIndex,&nbsp;greenIndex,&nbsp;blueIndex]&nbsp;=&nbsp;lookups.Lookups.Count;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;weight&nbsp;=&nbsp;Volume(cube,&nbsp;data.Weights);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(weight&nbsp;&lt;=&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lookup&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Lookup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Alpha&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)&nbsp;(Volume(cube,&nbsp;data.MomentsAlpha)/weight),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Red&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)&nbsp;(Volume(cube,&nbsp;data.MomentsRed)/weight),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Green&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)&nbsp;(Volume(cube,&nbsp;data.MomentsGreen)/weight),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Blue&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)&nbsp;(Volume(cube,&nbsp;data.MomentsBlue)/weight)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lookups.Lookups.Add(lookup);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lookups;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</h2>
<h2>Building the Image</h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private static Bitmap ProcessImagePixels(Image sourceImage, QuantizedPalette palette)
        {
            var result = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format8bppIndexed);
            var newPalette = result.Palette;
            for (var index = 0; index &lt; palette.Colors.Count; index&#43;&#43;)
                newPalette.Entries[index] = palette.Colors[index];
            result.Palette = newPalette;

            BitmapData targetData = null;
            try
            {
                targetData = result.LockBits(Rectangle.FromLTRB(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, result.PixelFormat);
                const byte targetBitDepth = 8;
                var targetByteLength = targetData.Stride &lt; 0 ? -targetData.Stride : targetData.Stride;
                var targetByteCount = Math.Max(1, targetBitDepth &gt;&gt; 3);
                var targetSize = targetByteLength * result.Height;
                var targetOffset = 0;
                var targetBuffer = new byte[targetSize];
                var targetValue = new byte[targetByteCount];
                var pixelIndex = 0;

                for (var y = 0; y &lt; result.Height; y&#43;&#43;)
                {
                    var targetIndex = 0;
                    for (var x = 0; x &lt; result.Width; x&#43;&#43;)
                    {
                        var targetIndexOffset = targetIndex &gt;&gt; 3;
                        targetValue[0] = (byte)(palette.PixelIndex[pixelIndex] == -1 ? palette.Colors.Count - 1 : palette.PixelIndex[pixelIndex]);
                        pixelIndex&#43;&#43;;

                        for (var valueIndex = 0; valueIndex &lt; targetByteCount; valueIndex&#43;&#43;)
                            targetBuffer[targetOffset &#43; valueIndex &#43; targetIndexOffset] = targetValue[valueIndex];

                        targetIndex &#43;= targetBitDepth;
                    }

                    targetOffset &#43;= targetByteLength;
                }

                Marshal.Copy(targetBuffer, 0, targetData.Scan0, targetSize);
            }
            finally
            {
                if(targetData != null)
                    result.UnlockBits(targetData);
            }

            return result;
        }
</pre>
<div class="preview">
<pre id="codePreview" class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;Bitmap&nbsp;ProcessImagePixels(Image&nbsp;sourceImage,&nbsp;QuantizedPalette&nbsp;palette)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Bitmap(sourceImage.Width,&nbsp;sourceImage.Height,&nbsp;PixelFormat.Format8bppIndexed);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newPalette&nbsp;=&nbsp;result.Palette;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;palette.Colors.Count;&nbsp;index&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newPalette.Entries[index]&nbsp;=&nbsp;palette.Colors[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.Palette&nbsp;=&nbsp;newPalette;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;targetData&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;targetData&nbsp;=&nbsp;result.LockBits(Rectangle.FromLTRB(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;result.Width,&nbsp;result.Height),&nbsp;ImageLockMode.WriteOnly,&nbsp;result.PixelFormat);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">const</span>&nbsp;byte&nbsp;targetBitDepth&nbsp;=&nbsp;<span class="js__num">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetByteLength&nbsp;=&nbsp;targetData.Stride&nbsp;&lt;&nbsp;<span class="js__num">0</span>&nbsp;?&nbsp;-targetData.Stride&nbsp;:&nbsp;targetData.Stride;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetByteCount&nbsp;=&nbsp;<span class="js__object">Math</span>.Max(<span class="js__num">1</span>,&nbsp;targetBitDepth&nbsp;&gt;&gt;&nbsp;<span class="js__num">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetSize&nbsp;=&nbsp;targetByteLength&nbsp;*&nbsp;result.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetOffset&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetBuffer&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;byte[targetSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetValue&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;byte[targetByteCount];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pixelIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;y&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;y&nbsp;&lt;&nbsp;result.Height;&nbsp;y&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;x&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;x&nbsp;&lt;&nbsp;result.Width;&nbsp;x&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;targetIndexOffset&nbsp;=&nbsp;targetIndex&nbsp;&gt;&gt;&nbsp;<span class="js__num">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;targetValue[<span class="js__num">0</span>]&nbsp;=&nbsp;(byte)(palette.PixelIndex[pixelIndex]&nbsp;==&nbsp;-<span class="js__num">1</span>&nbsp;?&nbsp;palette.Colors.Count&nbsp;-&nbsp;<span class="js__num">1</span>&nbsp;:&nbsp;palette.PixelIndex[pixelIndex]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelIndex&#43;&#43;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;valueIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;valueIndex&nbsp;&lt;&nbsp;targetByteCount;&nbsp;valueIndex&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;targetBuffer[targetOffset&nbsp;&#43;&nbsp;valueIndex&nbsp;&#43;&nbsp;targetIndexOffset]&nbsp;=&nbsp;targetValue[valueIndex];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;targetIndex&nbsp;&#43;=&nbsp;targetBitDepth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;targetOffset&nbsp;&#43;=&nbsp;targetByteLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(targetBuffer,&nbsp;<span class="js__num">0</span>,&nbsp;targetData.Scan0,&nbsp;targetSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(targetData&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.UnlockBits(targetData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">Here we simply use our generated palette and fill in the pixels.</p>
<p>&nbsp;</p>
<p>In the provided sample you will also find a .exe you can use to test this quantizer and generate a quantized 8 bit PNG. To use it simply build the solution and then navigate to the folder containing the compiled nQuant.exe. The executable takes a source
 path parameter which should be a path of any image you want to quantize. The executable will create a new image in the same directory as the source image and with the same name but appended with -quant. So the following command:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>
<pre class="hidden">nquant c:\myimage.png</pre>
<div class="preview">
<pre class="windowsshell">nquant&nbsp;c<span class="windowsshell__commandext">:</span>\myimage.png</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This will generate a quantized image in the root of c:\ named myimage-quant.png.</div>