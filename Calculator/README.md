# Calculator
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C++
## Topics
- C++
## Updated
- 08/23/2015
## Description

<h1>A little about the creator</h1>
<p>&nbsp;</p>
<p style="text-align:center">Hi,I am Gordan.I come from the UK.I have been programming for 6 months.My first language that I learned was HTML5,and then came others like CSS,JS,VB.Net...In my fifth month I started learning C&#43;&#43; and I am still learning it.<br>
I live in Liverpool,and I am 12 years old.&nbsp;</p>
<h1>THANK YOU SO MUCH FOR 100 DOWNLOADS!!!THE BIG UPDATE IS COMING SOON!!!!!</h1>
<h1></h1>
<p>&nbsp;</p>
<h1>WHAT IS NEW!!!</h1>
<p>*Absolute value is added!!!<br>
<br>
*Pow is added!!!<br>
<br>
*Settings are fixed!!!</p>
<p>*All bugs are fixed!!!</p>
<p>*Converter has been added!!!</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2></h2>
<h1>&nbsp;Description</h1>
<p style="text-align:left">This is a scientific calculator.It has all the basic operations with some advanced.<br>
<br>
</p>
<p>Like:</p>
<p>sin,cos,tan,sqr,sqrt,cosh(still in dev),sinh(still in dev),tanh(still in dev).</p>
<p>&nbsp;</p>
<h1>Code Source<br>
<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#include&nbsp;&lt;iostream&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;cmath&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;ccomplex&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;complex&gt;</span><span class="cpp__keyword">void</span>&nbsp;calculate();&nbsp;
<span class="cpp__keyword">namespace</span>&nbsp;pi{&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">double</span><span class="cpp__keyword">const</span>&nbsp;pi&nbsp;=&nbsp;<span class="cpp__number">3.1415926535897932384626433832795</span>;&nbsp;&nbsp;
&nbsp;
&nbsp;
}&nbsp;
<span class="cpp__keyword">namespace</span>&nbsp;e{&nbsp;
&nbsp;
<span class="cpp__datatype">double</span><span class="cpp__keyword">const</span>&nbsp;e&nbsp;=&nbsp;<span class="cpp__number">2.718</span>;&nbsp;
&nbsp;
&nbsp;
}&nbsp;
<span class="cpp__keyword">using</span><span class="cpp__keyword">namespace</span>&nbsp;std;&nbsp;
&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;main(){&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;options;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;choose;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">double</span>&nbsp;num1,num2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">double</span>&nbsp;sum&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
begin:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Welcome&nbsp;to&nbsp;my&nbsp;calculator&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;To&nbsp;calculate&nbsp;press&nbsp;C&nbsp;for&nbsp;help&nbsp;H&nbsp;and&nbsp;to&nbsp;exit&nbsp;E.&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cin&nbsp;&gt;&gt;&nbsp;options;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(options&nbsp;=&nbsp;<span class="cpp__number">67</span>){&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
calc:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Enter&nbsp;a&nbsp;x&nbsp;value&quot;</span>&nbsp;&lt;&lt;&nbsp;flush;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cin&nbsp;&gt;&gt;&nbsp;num1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Enter&nbsp;a&nbsp;y&nbsp;value&quot;</span>&nbsp;&lt;&lt;&nbsp;flush;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cin&nbsp;&gt;&gt;&nbsp;num2;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Choose&nbsp;your&nbsp;operator&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;1)&#43;,-,*,/;&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;2)sqr,sqrt&quot;</span>&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;3)sin,cos,tan&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;4)sinh,cosh,tanh&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;5)Constants&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cin&nbsp;&gt;&gt;&nbsp;choose;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(choose)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">43</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;num1&nbsp;&#43;&nbsp;num2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;num1&nbsp;&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&#43;&quot;</span>&nbsp;&lt;&lt;&nbsp;num2&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;=&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">45</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;num1&nbsp;-&nbsp;num2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;-&quot;</span>&nbsp;&lt;&lt;&nbsp;num2&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;=&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">42</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;num1&nbsp;*&nbsp;num2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;*&quot;</span>&nbsp;&lt;&lt;&nbsp;num2&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;=&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">47</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(num2&nbsp;==&nbsp;<span class="cpp__number">0</span>){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Invalid&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;num1&nbsp;/&nbsp;num2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;/&quot;</span>&nbsp;&lt;&lt;&nbsp;num2&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;=&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">83</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum=&nbsp;num1&nbsp;*&nbsp;num1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;num1&nbsp;&nbsp;&nbsp;&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;on&nbsp;squared&nbsp;is&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;&nbsp;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">81</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;sqrt(num1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;The&nbsp;squared&nbsp;root&nbsp;of&nbsp;&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;&nbsp;is&nbsp;equal&nbsp;to&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">113</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;sqrt(num1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;The&nbsp;squared&nbsp;root&nbsp;of&nbsp;&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;&nbsp;is&nbsp;equal&nbsp;to&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">115</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum=&nbsp;num1&nbsp;*&nbsp;num1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;num1&nbsp;&nbsp;&nbsp;&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;on&nbsp;squared&nbsp;is&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;&nbsp;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">84</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;tan(num1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;The&nbsp;tangent&nbsp;of&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;is&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">79</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;cos(num1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;The&nbsp;cosine&nbsp;of&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;is&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">73</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;=&nbsp;sin(num1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;The&nbsp;sine&nbsp;of&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;num1&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;&nbsp;&nbsp;is&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;sum&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">53</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;<span class="cpp__string">&quot;The&nbsp;value&nbsp;of&nbsp;PI&nbsp;is&nbsp;&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;pi::pi&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;The&nbsp;value&nbsp;of&nbsp;Euler's&nbsp;constant&nbsp;is&nbsp;&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;e::e&nbsp;&lt;&lt;&nbsp;endl;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">default</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Operator&nbsp;does&nbsp;not&nbsp;exist&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Do&nbsp;you&nbsp;want&nbsp;to&nbsp;exit&nbsp;or&nbsp;do&nbsp;more&nbsp;calculations&quot;</span>&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cin&nbsp;&gt;&gt;&nbsp;options;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cpp__keyword">while</span>&nbsp;((choose&nbsp;!=&nbsp;<span class="cpp__string">'&#43;'</span>)&nbsp;&amp;&amp;&nbsp;(choose&nbsp;!=&nbsp;<span class="cpp__string">'-'</span>)&nbsp;&amp;&amp;&nbsp;(choose&nbsp;!=&nbsp;<span class="cpp__string">'*'</span>)&nbsp;&amp;&amp;&nbsp;(choose&nbsp;=&nbsp;<span class="cpp__string">'/'</span>)&nbsp;);&nbsp;
&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>(options){&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">67</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">goto</span>&nbsp;calc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">69</span>&nbsp;:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;abort();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span><span class="cpp__number">72</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;<span class="cpp__string">&quot;This&nbsp;is&nbsp;a&nbsp;scientific&nbsp;calculator.It&nbsp;has&nbsp;basic&nbsp;operations,advanced&nbsp;operations.As&nbsp;you&nbsp;would&nbsp;expect&nbsp;for&nbsp;the&nbsp;basic&nbsp;operations&nbsp;it&nbsp;is&nbsp;their&nbsp;signs,but&nbsp;for&nbsp;the&nbsp;advanced&nbsp;goes&nbsp;&quot;</span>&nbsp;&lt;&lt;endl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;Geometry&nbsp;funtions:sin-I,cos-O&nbsp;and&nbsp;the&nbsp;tan-T;(all&nbsp;functions&nbsp;must&nbsp;be&nbsp;uppercase&nbsp;letters).&quot;</span>&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__string">&quot;For&nbsp;functions:sqr-S,sqrt-Q;(uppercase&nbsp;letters)&quot;</span>&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">goto</span>&nbsp;begin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;system(<span class="cpp__string">&quot;pause&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cin.get();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span><span class="cpp__number">0</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The definition of a calculator</div>
</h1>
<p>1) A calculator is a device that performs arithmetic operations on numbers. The simplest calculators can do only addition, subtraction, multiplication, and division. More sophisticated calculators can handle&nbsp;<a href="http://whatis.techtarget.com/definition/exponent">exponent</a>&nbsp;ial
 operations, roots,&nbsp;<a href="http://searchcio-midmarket.techtarget.com/definition/logarithm">logarithm</a>&nbsp;s, trigonometric functions, and hyperbolic functions. Internally, some calculators actually perform all of these functions by repeated processes
 of addition.</p>
<p>Most calculators these days require electricity to operate. Portable, battery-powered calculators are popular with engineers and engineering students. Before 1970, a more primitive form of calculator, the&nbsp;<a href="http://searchcio-midmarket.techtarget.com/definition/logarithm">slide
 rule</a>&nbsp;, was commonly used. It consisted of a slat of wood, called the slide, that could be moved in and out of a reinforced pair of slats. Both the slide and the outer pair of slats had calibrated numerical scales. A movable, transparent sleeve called
 the cursor was used to align numerals on the scales. The slide rule did not require any source of power, but its precision was limited, and it was necessary to climb a learning curve to become proficient with it.</p>
<p>One of the most primitive calculators, the&nbsp;<a href="http://whatis.techtarget.com/definition/abacus">abacus</a>&nbsp;is still used in some regions of the Far East. The abacus uses groups of beads to denote numbers. Like the slide rule, the abacus requires
 no source of power. The beads are positioned in several parallel rows, and can be moved up and down to denote arithmetic operations. It is said that a skilled abacus user can do some calculations just as fast as a person equipped with a battery-powered calculator.</p>
<p>As calculators became more advanced during the 1970s, they became able to make computations involving variables (unknowns). These were the first personal computers. Today's personal computers can still perform such operations, and most are provided with
 a virtual calculator program that actually looks, on screen, like a handheld calculator. The buttons are actuated by pointing and clicking.</p>
<p>Theoretically, a modern computer is a calculator that works with&nbsp;<a href="http://searchcio-midmarket.techtarget.com/definition/binary">binary</a>&nbsp;numbers and has a much larger memory. But in the practical sense, a computer is far more than a mere
 calculator, because of the wide variety of non-computational tasks it can perform.</p>
<p>2) A calculator is a person who performs arithmetic or other mathematical calculations.</p>
<h1>
<div class="endscriptcode"></div>
</h1>
<p>&nbsp;</p>
<h1>I am ready for critics,and if you have a solution to these bugs send me a message(please)!!!!<br>
<br>
Send a mail at&nbsp;</h1>
<p>gordandjuric@hotmail.com or at gordancraft@hotmail.com</p>
<p>&nbsp;</p>
<h1>Thank you for downloading my sample<br>
AGAIN THANK YOU FOR 100 DOWNLOADS !!!!!!&nbsp;</h1>
