# CollectionView Tips - MVVM developers should love CollectionView
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- DataGrid
- Collections
- MVVM
- ObservableCollection
- ItemsSource
- CollectionViewSource
- CollectionView
## Updated
- 12/01/2014
## Description

<h1>Introduction</h1>
<p>This sample is a collection of tips to using the CollectionView.</p>
<p>The major tip being that it is VERY useful to the MVVM developer.</p>
<p>&nbsp;</p>
<p><span style="color:#ff00ff">It takes quite a lot of work to write these articles. If you like the sample and or explanation, please take the time to give it a 5 star rating. Thanks.</span></p>
<h1><span>Building the Sample</span></h1>
<p>The sample was written using VS2013 targetting .net4.51. &nbsp;There is a dependency on MVVM Light - but the dll are in the bin so you should be ok just to f5. &nbsp;MVVM light is freely availabble via nuget.</p>
<p>[toc] <br>
<br>
</p>
<hr>
<p>&nbsp;</p>
<p><span style="font-size:11.8181819915771px">The CollectionView offers significant benefits to Developers. The aim of this article is to point these out and offer some tips using them.</span></p>
<p><br>
There are plenty of resources on the web listing the various functions of <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionview(v=vs.110).aspx">
CollectionView</a>.&nbsp;&nbsp; The majority are introductory articles covering breadth rather than depth.<br>
For advanced usage the developer mostly has to pick through forum posts. &nbsp;The reader unfamiliar with CollectionView should probably read some of those before this article - some are listed in the Further Reading section below.<br>
<br>
</p>
<h2><a name="Audience"></a><span style="color:#0070c0">Audience</span></h2>
<p><br>
The article is aimed at the intermediate to advanced WPF developer and it is assumed the reader will read those introductory articles for further broader knowledge.&nbsp;&nbsp;<span style="font-size:11.8181819915771px">By definition we&rsquo;re talking collections
 and to the business developer that usually means DataGrids - which we will focus on.</span><br>
<br>
This article is best read with reference to the sample application&nbsp;since the reader will be able to see the full working code and experiment with it. &nbsp; Since this is intended for an audience who will be confident reading code the explanations of code
 will be kept brief. &nbsp;It's already quite a long article.<br>
<br>
The sample is intended to illustrate specific&nbsp;techniques rather than industry best practices. &nbsp;<br>
<br>
</p>
<h2><span style="color:#0070c0"><a name="Broad_Functionality"></a>Broad Functionality</span></h2>
<p>It&rsquo;s worth at least listing broad functionality before leaping into specifics.&nbsp; As it&rsquo;s name suggests the ICollectionView is a View on some sort of Collection.&nbsp; It allows you to manipulate a collection which you are going to bind to
 the UI. &nbsp;<br>
You can:<br>
<br>
</p>
<ul>
<li>Sort </li><li>Group </li><li>Filter </li><li>Traverse by setting Current record </li><li>Iterate all qualifying (filtered) items </li><li>Find the Index of an item </li><li>Raise event on Add/Remove of item </li></ul>
<p>There are several classes which inherit from ICollectionView &nbsp;but this article will gloss over the details and focus on CollectionView and ListCollectionView. If in doubt, choose
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.listcollectionview(v=vs.110).aspx">
ListCollectionView</a>.&nbsp;<br>
<br>
</p>
<h2><span style="color:#0070c0"><a name="Advantages"></a>Advantages</span></h2>
<p>There are several significant advantages of the CollectionView &nbsp;which are particularly appealing to the MVVM developer. &nbsp;From the ViewModel the developer may:</p>
<ul>
<li><span style="font-size:12.1px">Set current and hence selected record in the View.</span>
</li><li><span style="font-size:12.1px">Detect and handle user insertion or deletion from the View.</span>
</li><li>Work with all the items as they will be presented - because it&rsquo;s not virtualised.
</li><li>Introduce another layer allowing cleaner decoupling of data </li><li>Filter very flexibly </li></ul>
<p>It&rsquo;s worth stressing here that you can keep the ViewModel and View totally decoupled whilst carrying out this manipulation. Great for the MVVM developer. &nbsp;&nbsp;</p>
<h2><span style="color:#0070c0"><a name="Usage"></a>Usage</span></h2>
<h3><span style="color:#0070c0"><a name="Introduction"></a>Usage Introduction</span></h3>
<p>&nbsp;</p>
<p>MVVM developers often bind an ObservableCollection&lt;T&gt; to the ItemsSource of a DataGrid ( or ItemsControl ).&nbsp; Instead of binding directly to the ObservableCollection, the sample instead binds to a CollectionView whose source is an ObservableCollection.</p>
<h3><span style="color:#0070c0"><a name="First_obtain_your_CollectionView"></a>First obtain your CollectionView</span></h3>
<p>Most code samples you see will have something like:</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">MyView = (CollectionView)CollectionViewSource.GetDefaultView(myObservableCollection);</code></span></div>
</div>
<p><br>
As it says, that's obtaining the default view of the collection and it's often not really necessary to think any further than that.<br>
&nbsp;&nbsp;<br>
This is fine until you decide you wish to use that one collection twice. If you set up two views in this way you will find as you manipulate one of them ( say by filtering ) then something surprising happens.&nbsp; The two CollectionViews are actually referencing
 the same <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionviewsource(v=vs.110).aspx">
CollectionViewSource </a>and you will find both are filtered. In order to avoid this you need to instantiate your own CollectionViewSource rather than use the default.
<br>
CollectionViewSource is one of the things which lies off the road most often travelled and therefore explanations are thin on the ground. You often don't really need to know about it at all as you're getting that default view and of course that's where most
 blogger and developers interest ends. &nbsp;The key thing to bear in mind is you need different
<span style="font-size:11.8181819915771px">CollectionViewSources&nbsp;</span>if you are going to manipulate one collection in two different ways. &nbsp;Not much else matters.<br>
The CollectionViewSource is an object so you can explicitly declare one and instantiate it.<br>
It has a Source property which is used to point to any collection. &nbsp;Yes that's right - the collectionviewsource itself has a source.<br>
You could therefore do: <br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">CollectionViewSource cvs = new CollectionViewSource();</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">cvs.Source = People;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">PeopleView = (CollectionView)cvs.View;</code></span></div>
</div>
<p>TwoCollectionViewsViewModel uses one line for each of it's two views:</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">PeopleView = (CollectionView)new CollectionViewSource { Source = People }.View;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">LevelsPeopleView = (CollectionView)new CollectionViewSource { Source = People }.View;</code></span></div>
</div>
<p>&nbsp;</p>
<p><span style="font-size:9.5pt; font-family:Consolas; color:black; background-color:white">A filter predicate is then applied which will only affect
<span style="font-size:11.8181819915771px; font-family:monospace; color:#000000; background-color:#ffffff">
LevelsPeopleView</span>:</span></p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">LevelsPeopleView.Filter = FirstOfLevel_Filter;</code></span></div>
</div>
<p><br>
This is how TwoCollectionViewsViewModel uses the one collection to show a list of levels in one datagrid ( the left one ) &nbsp;and the list of People in another.
<br>
Filtering will be explained in a later section. <br>
<br>
The technique here means both DataGrids have the same underlying objects bound for each row.&nbsp; When the user selects what appears to them to be a level in summary to the left that is literally the first Person object qualifying in the datagrid to the right.&nbsp;
 That can be used to make that Person the current one in the main DataGrid.</p>
<p>However you obtain your CollectionView, this will be what the ItemsSource of the DataGrid binds to.</p>
<p><span style="font-size:9.5pt; font-family:Consolas; color:black"><br>
</span></p>
<h2><span style="color:#0070c0"><a name="Sorting"></a>Sorting</span></h2>
<p>You may sort your collection using the CollectionView by adding to the <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionviewsource.sortdescriptions(v=vs.110).aspx">
SortDescriptors</a> collection.</p>
<p>When you do this then the CollectionView uses reflection on your type to decide what those strings in each SortDescriptor actually translate into. &nbsp;This may mean you want to consider writing your own custom IComparer because that can use a type known
 at compilation and hence will be quicker.&nbsp; You&rsquo;d spend a long time looking for a way to use that IComparer with just a CollectionView though.</p>
<p>If you wish to use this technique then use a ListCollectionView since it has a CustomSort property.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">listCollectionView.CustomSort = new customIComparer();</code></span></div>
</div>
<p><br>
Let's consider custom sorting first. &nbsp;DynamicFilteringViewModel uses a custom sort:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">PeopleView.CustomSort = new PersonComparer();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&hellip;..</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public class PersonComparer : IComparer</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">public int Compare(object x, object y)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">Person p1 = x as Person;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">Person p2 = y as Person;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">int result = p1.OrganizationLevel.CompareTo(p2.OrganizationLevel);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">if (result == 0)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">result = p1.LastName.CompareTo(p2.LastName);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">if (result == 0)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">result = p1.FirstName.CompareTo(p2.FirstName);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">return result;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
</div>
<p><br>
Notice that multiple sort criteria are quite tricky to deal with. The code applies OrganizationLevel as the primary sort, then LastName and then FirstName.&nbsp; It is arguable whether the added efficiency repays the effort and somewhat obscure code. &nbsp;
<br>
<br>
The sort is in ascending order, if you wanted to sort in descending order then you would switch p1 and p2 around for the CompareTo:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">int result = p2.OrganizationLevel.CompareTo(p1.OrganizationLevel);</code></span></div>
</div>
<p><br>
SortDescriptions are much easier to understand and the sample has the relevant lines of code commented out, so you can easily try them.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">PeopleView.SortDescriptions.Clear();</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">PeopleView.SortDescriptions.Add(new SortDescription(&quot;OrganizationLevel&quot;, ListSortDirection.Ascending));</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">PeopleView.SortDescriptions.Add(new SortDescription(&quot;LastName&quot;, ListSortDirection.Ascending));</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">PeopleView.SortDescriptions.Add(new SortDescription(&quot;FirstName&quot;, ListSortDirection.Ascending));</code></span></div>
</div>
<p>&nbsp;</p>
<p>The developer is best advised to present a maximum of 300 or so records at a time to the user in any collection.&nbsp; With this in mind the inefficiency of SortDescriptors can often be irrelevent and this is usually the best approach.<br>
<br>
<span style="font-size:11.8181819915771px">Of course you can still sort the underlying collection and not use the sorting facilites in CollectionView - this is most useful in scenarios where the users want the one sort order and the collection is not particularly
 dynamic. Maybe that list of personnel as it was yesterday is going to be good enough all day today.</span><br style="font-size:11.8181819915771px">
</p>
<p style="font-size:11.8181819915771px">You will see the TwoCollectionViews usercontrol &nbsp;uses LINQ</p>
<div class="reCodeBlock" style="font-size:11.8181819915771px; border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">People = new ObservableCollection&lt;</code><code style="color:#006699; font-weight:bold">Person</code><code style="color:#000000">&gt;(</code></span></div>
<div style="background-color:#f8f8f8"><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:52px!important"><code style="color:#000000">ppl.OrderBy(x=&gt;x.OrganizationLevel)</code></span></div>
<div style="background-color:#ffffff"><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:52px!important"><code style="color:#000000">.ThenBy(x=&gt;x.LastName).ThenBy(x=&gt;x.FirstName).Select(x=&gt;x).ToList());</code></span></div>
</div>
<p><br style="font-size:11.8181819915771px">
</p>
<p style="font-size:11.8181819915771px">This sort would need to be repeated if an item was added but is easy to write if you are used to working with LINQ. &nbsp;Arguably still easier to write than the somewhat obscure&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.collections.icomparer(v=vs.110).aspx%20">IComparer</a>&nbsp;(
 as you will soon see )</p>
<p>&nbsp;</p>
<h2><span style="color:#0070c0"><a name="Filtering"></a>Filtering</span></h2>
<p><br>
This is a very useful aspect of the CollectionView due to the fact you can use the ObservableCollection as a sort of repository and change just the filtering as the user chooses different criteria.
<br>
<br>
As <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionview.filter(v=vs.110).aspx">
MSDN</a> says -&nbsp;the filter is a Predicate method which is used to decide whether a row is included in the view or not.&nbsp; Return true and it&rsquo;s included, false and it&rsquo;s not.&nbsp; MSDN shows very simple filters and the first of these is shown
 below ( to encourage the reader to keep reading).<br>
<br>
</p>
<h3><span style="color:#0070c0"><a name="Simple_Filtering"></a>Simple Filtering</span></h3>
<p>From MSDN:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private void ShowOnlyBargainsFilter(object sender, FilterEventArgs e)</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">AuctionItem product = e.Item as AuctionItem;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (product != null)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">// Filter out products with price 25 or above
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (product.CurrentPrice &lt; 25)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">e.Accepted = true;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">else</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">e.Accepted = false;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
<h3><span style="color:#0070c0"><a name="Slightly_more_Complicated"></a>Slightly more Complicated</span></h3>
<p><br>
The sample demonstrates a slightly more complicated filter and a very flexible one. &nbsp;</p>
<p>TwoCollectionsView offers the user the ability to click on a level in the left datagrid and navigate to the first Person of that level in the right.</p>
<p>In order to pick out just the first person in each level (for the left DataGrid ) the filter relies on the fact the collection is iterated first to last.&nbsp; It returns true if the level changes from the last .</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private int LastLevel = -1;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">private bool FirstOfLevel_Filter(object item)</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Person p = item as Person;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (p != null)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (p.OrganizationLevel == LastLevel)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:44px!important"><code style="color:#000000">return false;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">LastLevel = p.OrganizationLevel;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">return true;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">return false;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
The code is pretty self explanatory, setting LastLevel so the first will definitely qualify and using that variable to decide which is the first of each level.<br>
<br>
</p>
<h3><span style="color:#0070c0"><a name="Complicated_Filtering"></a>Complicated Filtering</span></h3>
<p>&nbsp;</p>
<p>The DynamicFilteringView allows the user to pick from a selection of criteria and Filter on any mix of these on a click of the Filter button.</p>
<p>DynamicFilteringViewModel lives up to it&rsquo;s name by illustrating a very flexible approach using a list of predicates.&nbsp; Where any of them are false it returns false by using some LINQ to iterate through all the predicates:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private List&lt;</code><code style="color:#006699; font-weight:bold">Predicate</code><code style="color:#000000">&lt;Person&gt;&gt; criteria = new List&lt;</code><code style="color:#006699; font-weight:bold">Predicate</code><code style="color:#000000">&lt;Person&gt;&gt;();</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private bool dynamic_Filter(object item)</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Person p = item as Person;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">bool isIn = true;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (criteria.Count() == 0)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">return isIn;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">isIn = criteria.TrueForAll(x =&gt; x(p));</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">return isIn;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
The list is first cleared and then <span style="font-size:11.8181819915771px">selected&nbsp;</span>criteria are added.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private void ExecuteApplyFilter()</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">DateTime _zeroDay = new DateTime(1, 1, 1);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">DateTime _now = DateTime.Now;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">criteria.Clear();</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (yearsChosen &gt; 0)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">criteria.Add(new Predicate&lt;</code><code style="color:#006699; font-weight:bold">Person</code><code style="color:#000000">&gt;(x
 =&gt; yearsChosen &lt; (</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">(_zeroDay &#43; (_now - x.BirthDate)).Year - 1)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:240px!important"><code style="color:#000000">));</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (letterChosen != &quot;Any&quot;)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">criteria.Add(new Predicate&lt;</code><code style="color:#006699; font-weight:bold">Person</code><code style="color:#000000">&gt;(x
 =&gt; x.LastName.StartsWith(letterChosen)));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (genderChosen != &quot;Any&quot;)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">criteria.Add(new Predicate&lt;</code><code style="color:#006699; font-weight:bold">Person</code><code style="color:#000000">&gt;(x
 =&gt; x.Gender.Equals(genderChosen.Substring(0, 1))));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">PeopleView.Filter = dynamic_Filter;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">RaisePropertyChanged(&quot;PeopleView&quot;);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">// Bring the current person back into view in case it moved</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (CurrentPerson != null)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Person current = CurrentPerson;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">PeopleView.MoveCurrentToFirst();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">PeopleView.MoveCurrentTo(current);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
</div>
<p><br>
<br>
The user picks from any of several options, any picked are added to the list of predicates with &nbsp;the specific value to compare. &nbsp;If there are no criteria then everything qualifies, if not then all are checked and must be true for true to be returned
 and the record included.</p>
<p>All but the most complicated requirements can usually be broken down into simple steps and tackled with this approach. &nbsp;A particular advantage is that each of the &nbsp;individual criteria can be simple, discrete and easy to understand. &nbsp;Should
 something go wrong then you can test each criteria separately.<br>
There's probably a pattern with a name for this technique somewhere.<br>
<br>
</p>
<h3><span style="color:#0070c0"><a name="Performance_and_Repository"></a>Performance and Repository</span></h3>
<p><br>
By decoupling the presentation from the underlying ObservableCollection of data, filtering offers a useful way of improving
<span style="font-size:11.8181819915771px">perceived&nbsp;</span>performance. The window can load a small subset of data initially with a filter set to say the user&rsquo;s team data or top 100 records. The user will then get to see this data quickly and the
 filter will be matched by an obvious UI indicator of some sort like a ComboBox default.&nbsp;
<br>
<br>
An asynchronous task or service call can then be made for another set of data added to the ObservableCollection. The UI will not change because the filter is in place.
<br>
<br>
Or a subset can be shown initially and the user will only see a small change as the next 50 or so records are fetched.
<br>
<br>
This process can be repeated with a chain of calls and or it can be done as a lazy load as the user chooses a different filter criteria.
<br>
<br>
Since the contents of the ObservableCollection do not have thread affinity, each subset of data can be safely appended from within a non UI thread without any Dispatcher.Invoke complications. In this manner the ObservableCollection will eventually be filled
 and the user can switch filters and see the data immediately. This approach is simpler than using a separate repository which of course might occasionally be preferable.
<br>
<br>
</p>
<h2><span style="color:#0070c0"><a name="Programmatic_Selection_of_Record"></a>Programmatic Selection of Record</span></h2>
<p><br>
The ability to set current record in the ViewModel and that then selects it in the View.<br>
This is a great feature of the CollectionView which sounds&nbsp;absolutely brilliant at first, but there&rsquo;s a complication.<br>
&nbsp;<br>
</p>
<h3><span style="color:#0070c0"><a name="The_Good"></a>The Good<br>
</span></h3>
<p><span style="font-size:11pt; font-family:Calibri,sans-serif"><br>
When you set&nbsp;IsSynchronizedWithCurrentItem:<br>
<br>
</span></p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid</code>
<code style="color:#000000">&hellip;&hellip;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:40px!important"><code style="color:#808080">IsSynchronizedWithCurrentItem</code><code style="color:#000000">=</code><code style="color:blue">&quot;True&quot;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:40px!important"><code style="color:#808080">EnableRowVirtualization</code><code style="color:#000000">=</code><code style="color:blue">&quot;True&quot;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:40px!important"><code style="color:#000000">&gt;
</code></span></span></div>
</div>
<p><br>
This means the selecteditem in the view will match the current item in your bound collectionview. &nbsp; &nbsp;You can set current in several ways, the most useful being MoveCurrentTo().&nbsp;
<br>
You can see this working as you spin the application up. The Viewmodel uses CollectionView.MoveCurrentTo:</p>
<p>&nbsp;</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">private Person CurrentPerson</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">get { return PeopleView.CurrentItem as Person; }</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">set
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">{
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">PeopleView.MoveCurrentTo(value);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">RaisePropertyChanged();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&hellip;&hellip;.</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">Person _person = ppl[121];</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">CurrentPerson = _person;</code></span></span></div>
</div>
<p><br>
<br>
This makes the 121st Person in the list the Current item in the collection and the DataGridRow becomes the selected item in the DataGrid.<br>
The DataGrid is virtualized by default but the reader may notice the property is explicitly set to true just to underline this. &nbsp;
<br>
What;s so great about that? <br>
If the code instead used a DataGridRow to navigate then there would be a problem with selecting that item since it would be virtual. There would be no corresponding control to select.
<br>
The convenience of not needing to worry about Virtualized rows is one of the plusses of CollectionView. &nbsp;As you can see, MoveCurrentTo copes with an item which is virtualized with no problem.
<span style="font-size:11pt; font-family:Calibri,sans-serif; color:#0070c0">&nbsp;</span></p>
<h3><a name="The_not_so_Good"></a><span style="color:#0070c0">The not so Good</span></h3>
<p>&nbsp;</p>
<p>There is a &ldquo;gotcha&rdquo; with this MoveCurrentTo.&nbsp; It suffers from the same issue which making a datagridrow selected does.&nbsp; The problem is that the row in the view is current but it will not have focus and it may not be in view.&nbsp; Just
 doing MoveCurrentTo will give you a very light grey background on a row which the user has to scroll down to.&nbsp; Not good.&nbsp; But of course the sample quite clearly manages to focus the row. &nbsp;How's it do that?</p>
<h3><span style="color:#0070c0"><a name="Scrolling"></a>Scrolling</span></h3>
<p>The sample scrolls the selected row up into view by using a Behavior which is set on the DataGrid.</p>
<p>The behaviour is attached thus:</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid</code>
<code style="color:#000000">&hellip;&hellip;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:40px!important"><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">i:Interaction.Behaviors</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">support:ScrollDataGridRowIntoView</code>
<code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">i:Interaction.Behaviors</code><code style="color:#000000">&gt;</code></span></span></div>
</div>
<p>&nbsp;</p>
<p>The <span style="font-size:9.5pt; font-family:Consolas; color:black">critical part of the code is where it calls ScrollIntoView on the selected item.<br>
<br>
</span></p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">datagrid.ScrollIntoView(datagrid.SelectedItem);</code></span></div>
</div>
<p><br>
Full Behavior:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">class ScrollDataGridRowIntoView : Behavior&lt;</code><code style="color:#006699; font-weight:bold">DataGrid</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">protected override void OnAttached()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">base.OnAttached();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">this.AssociatedObject.SelectionChanged &#43;= AssociatedObject_SelectionChanged;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">if (sender is DataGrid)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">DataGrid datagrid = (sender as DataGrid);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">if (datagrid.SelectedItem != null)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">datagrid.Dispatcher.BeginInvoke(
 (Action)(() =&gt; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:96px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:112px!important"><code style="color:#000000">datagrid.UpdateLayout();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:112px!important"><code style="color:#000000">if
 (datagrid.SelectedItem !=&nbsp; null)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:112px!important"><code style="color:#000000">{
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:128px!important"><code style="color:#000000"><strong>datagrid.ScrollIntoView(datagrid.SelectedItem);</strong></code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:112px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:96px!important"><code style="color:#000000">}));</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">protected override void OnDetaching()</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">base.OnDetaching();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">this.AssociatedObject.SelectionChanged -=&nbsp; AssociatedObject_SelectionChanged;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
This works because as the DataGrid is synchronized setting the Current item in the CollectionView selects the corresponding DataGridRow in the view. SelectionChanging fires on the DataGrid and the ScrollIntoView is invoked.
<br>
The code could be simpler if implemented as an eventhandler.&nbsp; Making it a behaviour makes for easier re-use and centralises the code out from code behind in each Window/UserControl into a separate class.
<br>
So the user can see the row, even if it was out of view.<br>
&nbsp;<br>
This is only part of the story though.<br>
The row still hasn't got focus so it&rsquo;s still grey and not as obviously selected as a user will expect. &nbsp;The user also could not traverse rows in the grid just by clicking the up or down arrows.
<br>
<br>
</p>
<h3><span style="color:#0070c0"><a name="Focus"></a>Focus</span></h3>
<p>Focussing on the row is handled by an Attached Behavior. This has to be an Attached Behavior because we need to apply it via a style.&nbsp; You would get an error if you tried to connect a Behavior similar to the above one via a style.&nbsp; By making this
 such a Behavior it becomes re-usable like the scroll behavior but as you will see this comes at the price of a fair bit of added code.</p>
<p>The business part of this is very simple:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">DataGridRow row = e.OriginalSource as DataGridRow;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">// If focus is already on a cell then don't focus back out of it</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">if (!(Keyboard.FocusedElement is DataGridCell) &amp;&amp; row != null)</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">row.Focusable = true;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Keyboard.Focus(row);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
The full code looks quite complicated but is just there to attach that to the DataGridRow Selected event:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public static bool GetIsDataGridRowFocussedWhenSelected(DataGridRow dataGridRow)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">return (bool)dataGridRow.GetValue(IsDataGridRowFocussedWhenSelectedProperty);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public static void SetIsDataGridRowFocussedWhenSelected(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">DataGridRow dataGridRow, bool value)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">dataGridRow.SetValue(IsDataGridRowFocussedWhenSelectedProperty, value);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public static readonly DependencyProperty IsDataGridRowFocussedWhenSelectedProperty =</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">DependencyProperty.RegisterAttached(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&quot;IsDataGridRowFocussedWhenSelected&quot;,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">typeof(bool),</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">typeof(DataGridRowBehavior),</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">new UIPropertyMetadata(false, OnIsDataGridRowFocussedWhenSelectedChanged));</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">static void OnIsDataGridRowFocussedWhenSelectedChanged(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">DependencyObject depObj, DependencyPropertyChangedEventArgs e)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">DataGridRow item = depObj as DataGridRow;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (item == null)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">return;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (e.NewValue is bool == false)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">return;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if ((bool)e.NewValue)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">item.Selected &#43;= OndataGridRowSelected;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">else</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">item.Selected -= OndataGridRowSelected;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">static void OndataGridRowSelected(object sender, RoutedEventArgs e)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">DataGridRow row = e.OriginalSource as DataGridRow;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">// If focus is already on a cell then don't focus back out of it</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (!(Keyboard.FocusedElement is DataGridCell) &amp;&amp; row != null)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">row.Focusable = true;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">Keyboard.Focus(row);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
That is attached via a style:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid.RowStyle</code><code style="color:#000000">&gt;
</code></span></div>
<div style="background-color:#f8f8f8"><code style="font-size:12.1px; background-color:#ffffff">&nbsp; &nbsp;&nbsp;</code><span style="font-size:12.1px; margin-left:16px!important; background-color:#ffffff"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">Style</code>
<code style="color:#808080">TargetType</code><code style="color:#000000">=</code><code style="color:blue">&quot;{x:Type DataGridRow}&quot;</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">Setter</code>
<code style="color:#808080">Property</code><code style="color:#000000">=</code><code style="color:blue">&quot;support:DataGridRowBehavior.IsDataGridRowFocussedWhenSelected&quot;</code>
<code style="color:#808080">Value</code><code style="color:#000000">=</code><code style="color:blue">&quot;true&quot;</code><code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">Style</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">DataGrid.RowStyle</code><code style="color:#000000">&gt;</code></span></div>
</div>
<p><br>
<span style="font-size:11.8181819915771px">A full explanation of Attached Behaviors is outside the scope of this article but luckily Josh Smith already wrote a good&nbsp;</span><a href="http://www.codeproject.com/Articles/28959/Introduction-to-Attached-Behaviors-in-WPF" style="font-size:11.8181819915771px">article</a><span style="font-size:11.8181819915771px">.</span><br style="font-size:11.8181819915771px">
</p>
<p style="font-size:11.8181819915771px">Essentially this allows you to add behaviour via a WPF Attached Property.&nbsp; Simple attached behaviors can be added pretty much by cutting and pasting Josh&rsquo;s code from that article and modifying name, control
 type, event and of course the code which does stuff.</p>
<p style="font-size:11.8181819915771px">These two behaviors are kept separate largely for simplicity.&nbsp; There is, however, &nbsp;also the occasional requirement to bring into view but not focus or select without bringing into view.&nbsp;</p>
<p><br>
The Keyboard.Focus solution avoids having to walk the visual tree and find a cell to focus but introduces an edge case. &nbsp;For this to work, keyboard focus cannot already be on a datagrid cell. &nbsp;In most circumstances the user will have clicked a button,
 selected something on a combo or something which will guarantee this is not the case.<br>
<br>
TwoCollectionViews illustrates a possible complication by presenting the level choice in a DataGrid. &nbsp;The view still works because the DataGrid is ReadOnly and the one column set so it cannot take focus:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid</code>
<code style="color:#808080">x:Name</code><code style="color:#000000">=</code><code style="color:blue">&quot;dgLevels&quot;</code>&nbsp;
<code style="color:#808080">AutoGenerateColumns</code><code style="color:#000000">=</code><code style="color:blue">&quot;False&quot;</code></span></div>
<div style="background-color:#f8f8f8"><span style="font-family:monospace">..</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:40px!important"><strong><code style="color:#808080">IsReadOnly</code><code style="color:#000000">=</code><code style="color:blue">&quot;True&quot;</code></strong></span></span></div>
<div style="background-color:#f8f8f8"><code style="font-size:12.1px; background-color:#ffffff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</code><span style="font-size:12.1px; margin-left:40px!important; background-color:#ffffff"><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid.Resources</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><code>&nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></code><span style="margin-left:32px!important"><strong><code style="color:#000000">&lt;</code><code style="color:#006699">Style</code>
<code style="color:#808080">x:Key</code><code style="color:#000000">=</code><code style="color:blue">&quot;NoFocusStyle&quot;</code>
<code style="color:#808080">TargetType</code><code style="color:#000000">=</code><code style="color:blue">&quot;{x:Type DataGridCell}&quot;</code><code style="color:#000000">&gt;</code></strong></span></div>
<div style="background-color:#f8f8f8"><span><strong><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;</code><code style="color:#006699">Setter</code>
<code style="color:#808080">Property</code><code style="color:#000000">=</code><code style="color:blue">&quot;Focusable&quot;</code>
<code style="color:#808080">Value</code><code style="color:#000000">=</code><code style="color:blue">&quot;False&quot;</code><code style="color:#000000">/&gt;</code></span></strong></span></div>
<div style="background-color:#ffffff"><span><strong><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699">Style</code><code style="color:#000000">&gt;</code></span></strong></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">DataGrid.Resources</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid.Columns</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGridTextColumn</code>
<code style="color:#808080">Binding</code><code style="color:#000000">=</code><code style="color:blue">&quot;{Binding OrganizationLevel}&quot;</code>&nbsp;
<code style="color:#808080">Header</code><code style="color:#000000">=</code><code style="color:blue">&quot;Lvl&quot;</code>
<strong><code style="color:#808080">CellStyle</code><code style="color:#000000">=</code><code style="color:blue">&quot;{StaticResource NoFocusStyle}&quot;</code></strong>
<code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">DataGrid.Columns</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">DataGrid</code><code style="color:#000000">&gt;</code></span></div>
</div>
<p><br>
Other edge cases could be imagined but are rare enough that this approach is the first thing to try. &nbsp;If you absolutely need to have focus in one datagridcell when you traverse then there is a compromise you could take or a slightly different approach.
 &nbsp;<br>
<br>
</p>
<h3><a name="Compromise"></a><span style="color:#0070c0">Compromise<br>
<br>
</span></h3>
<p>If you remove the check on whether the Focusedelement is a datagridcell then it will always fire but the user will find they need two clicks on the up or down arrow to traverse rows. &nbsp; Some users never use the keyboard arrows like this or the usage
 of the DataGrid is such they rarely use the arrows. &nbsp;This compromise will be unacceptable for some groups of users whilst others won't notice.<br>
<br>
</p>
<h3><a name="No_Compromise"></a><span style="color:#0070c0">No Compromise<br>
<br>
</span></h3>
<p>Should that be a problem then the simple solution with two datagrids is to use code behind and the DataGridRow Selected event for both DataGrids. &nbsp;You can then set which has focus and only ignore when focus is in the current datagrid.<br>
You can tie yourself in knots trying to cope with all imaginary possible edge cases and the best way to handle these is as and when you see a real&nbsp;problem.<br>
<br>
</p>
<h3><a name="What_if_you_don_t_want_the_first_Cell"></a><span style="color:#0070c0">What if you don't want the first Cell?</span></h3>
<p><br>
Keyboard focus on the row turns it all blue (by default) and puts focus on the first cell which will take it. In the event that you don&rsquo;t wish to set focus to the first sell then that can be handled by setting IsTabStop=false on the cell of the column
 in question.&nbsp; You can see this used in TwoCollectionViews which will put the focus on the second column.</p>
<p>Like the DataGridRow there is no actual cell there to refer to directly in markup so this is done by a style:</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid.Resources</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">Style</code>
<code style="color:#808080">x:Key</code><code style="color:#000000">=</code><code style="color:blue">&quot;NoTabStopStyle&quot;</code>
<code style="color:#808080">TargetType</code><code style="color:#000000">=</code><code style="color:blue">&quot;{x:Type DataGridCell}&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">Setter</code>
<code style="color:#808080">Property</code><code style="color:#000000">=</code><code style="color:blue">&quot;KeyboardNavigation.IsTabStop&quot;</code>
<code style="color:#808080">Value</code><code style="color:#000000">=</code><code style="color:blue">&quot;False&quot;</code><code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">Style</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">DataGrid.Resources</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">Using this in a Datagrid column:</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid.Columns</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGridTextColumn</code>
<code style="color:#808080">Binding</code><code style="color:#000000">=</code><code style="color:blue">&quot;{Binding OrganizationLevel}&quot;</code>&nbsp;
<code style="color:#808080">Header</code><code style="color:#000000">=</code><code style="color:blue">&quot;Lvl&quot;</code>
<code style="color:#808080">CellStyle</code><code style="color:#000000">=</code><code style="color:blue">&quot;{StaticResource NoTabStopStyle}&quot;</code>
<code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGridTextColumn</code>
<code style="color:#808080">Binding</code><code style="color:#000000">=</code><code style="color:blue">&quot;{Binding JobTitle}&quot;</code>&nbsp;
<code style="color:#808080">Header</code><code style="color:#000000">=</code><code style="color:blue">&quot;Title&quot;</code>
<code style="color:#000000">/&gt;</code></span></span></div>
</div>
<p>&nbsp;</p>
<h2><span style="color:#0070c0"><a name="Row_Number"></a>Row Number</span></h2>
<h3><span style="color:#0070c0"><a name="Introduction"></a>Introduction</span></h3>
<p>On some rare occasions users will request an index on rows in a DataGrid.&nbsp; A particular tip on this is that users often change their minds when they realise this is not a reliable &ldquo;key&rdquo; identifying a record and that record is row 4 will
 change as they sort a DataGrid on a different column.&nbsp; It is easy enough to implement.&nbsp; Just bear in mind you may be taking it back out later and be careful to explain how it will work.&nbsp;</p>
<p>Still want one?</p>
<p>The requirement can be fulfilled using 3 different techniques.</p>
<h3><span style="color:#0070c0"><a name="Semi_Fixed_Row_Numbers"></a>Semi Fixed Row Numbers</span></h3>
<p>One possible requirement is for users who have an expected default sort order which they use almost all the time. This can be tackled using a filter.&nbsp; A filter will be applied by iterating all records in a view. You can increment a counter and update
 a property in the row viewmodel which is bound in the view:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private int LastLevel = -1;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">private int RowNo = 0;</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private bool FirstOfLevel_Filter(object item)</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Person p = item as Person;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (p != null)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (p.OrganizationLevel == LastLevel)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:44px!important"><code style="color:#000000">return false;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">LastLevel = p.OrganizationLevel;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">RowNo&#43;&#43;;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">p.RowNo = RowNo;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">return true;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">return false;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
<p>Here, an integer property RowNo is added to the Person object, incremented as each qualifies and would be bound in the view.&nbsp; Especially if you will be filtering anyway, this will add practically no overhead even if your underlying collection is big.</p>
<p>As the user clicks on column headers of the DataGrid to sort or adds a new item, these will not be re-evaluated unless you call CollectionView.Refresh.&nbsp; Note that calling Refresh is quite a heavy process.</p>
<h3><a name="Dynamic_Row_Numbers"></a><span style="color:#0070c0">Dynamic Row Numbers</span><br>
<br>
</h3>
<h3><a name="The_same_technique_is_used_in_both_methods_within_the_RowNo_Usercontrol_The_Row_Number_is_obtained_by_using_the_method_CollectionView_IndexOf_item_and_adding_1_The_complications_lie_in_where_that_is_called_One_approach_is_to_use_a_converter_A_static_is_used_as_a_bridging_class_to_pass_a_reference_to_the_CollectionView_efficiently_public_static_class_CVHolder_public_static_CollectionView_CV_public_class_RowFromObject_IValueConverter_public_object_Convert_object_value_Type_targetType_object_parameter_System_Globalization_CultureInfo_culture_int_rn_0_if_CVHolder_CV_null_value_null_return_rn_rn_CVHolder_CV_IndexOf_value_return_rn_43_1_public_object_ConvertBack_object_value_Type_targetType_object_parameter_System_Globalization_CultureInfo_culture_return_1_Used_in_the_View_lt_DataGrid_Columns_gt_lt_DataGridTextColumn_Binding_quot_Binding_Converter_StaticResource_rowfromobject_StringFormat_quot_Header_quot_Via_Converter_quot_gt_This_rather_complicates_what_would_otherwise_be_a_simple_method_but_keeps_the_row_viewmodel_clean_The_second_approach_is_demonstrated_in_the_PersonVM_viewmodel_which_is_passed_a_reference_to_the_CollectionView_class_PersonVM_NotifyUIBase_public_Person_ThePerson_get_set_public_CollectionView_CV_get_set_public_int_RowNo_get_int_row_1_row_CV_IndexOf_this_return_row_43_1_In_the_RowNoViewModel_we_can_see_the_CollectionView_set_in_the_row_viewmodels_and_the_bridging_static_People_new_ObservableCollection_lt_PersonVM_gt_ppl_OrderBy_x_gt_x_ThePerson_OrganizationLevel_ThenBy_x_gt_x_ThePerson_LastName_ThenBy_x_gt_x_ThePerson_FirstName_Select_x_gt_x_ToList_PeopleView_CollectionView_new_CollectionViewSource_Source_People_View_ppl_ForEach_p_gt_p_CV_PeopleView_CVHolder_CV_PeopleView_RaisePropertyChanged_quot_PeopleView_quot_People_CollectionChanged_43_People_CollectionChanged_void_People_CollectionChanged_object_sender_System_Collections_Specialized_NotifyCollectionChangedEventArgs_e_RefreshView_Note_also_how_the_CollectionChanged_event_is_handled_Insertion_or_deletion_will_fire_this_event_and_the_CollectionView_refresh_will_re-calculate_the_row_numbers_Raising_the_property_changed_even_then_tells_the_UI_to_read_the_values_again_private_object_RefreshView_PeopleView_Refresh_RaisePropertyChanged_quot_PeopleView_quot_return_null_The_user_can_also_sort_the_DataGrid_by_clicking_column_headers_the_DataGrid_sorting_event_will_be_fired_and_this_is_handled_in_code_behind_In_order_to_keep_the_View_and_ViewModel_de-coupled_the_View_uses_MVVM_Light_messaging_to_tell_the_ViewModel_to_refresh_the_CollectionView_private_void_dg_Sorting_object_sender_DataGridSortingEventArgs_e_var_msg_new_RefreshView_Messenger_Default_Send_lt_RefreshView_gt_msg_Registering_for_the_message_in_the_view_model_public_RowNoViewModel_if_DesignerProperties_GetIsInDesignMode_new_DependencyObject_GetData_InsertPerson_new_RelayCommand_lt_string_gt_ExecuteInsertPerson_Messenger_Default_Register_lt_RefreshView_gt_this_action_gt_RefreshView_Closing"></a></h3>
<p>The same technique is used in both methods within the RowNo Usercontrol.&nbsp; The Row Number is obtained by using the method CollectionView.IndexOf(item) and adding 1. The complications lie in where that is called.&nbsp; One approach is to use a converter.&nbsp;
 A static is used as a bridging class to pass a reference to the CollectionView efficiently.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">public static class CVHolder</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public static CollectionView CV;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000"><strong>public class RowFromObject : IValueConverter</strong></code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public object Convert(object value, Type targetType, object parameter, <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Globalization.CultureInfo.aspx" target="_blank" title="Auto generated link to System.Globalization.CultureInfo">System.Globalization.CultureInfo</a> culture)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">int rn = 0;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">if (CVHolder.CV == null || value == null)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">return rn;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000"><strong>rn = CVHolder.CV.IndexOf(value);</strong></code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">return rn&#43;1;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public object ConvertBack(object value, Type targetType, object parameter, <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Globalization.CultureInfo.aspx" target="_blank" title="Auto generated link to System.Globalization.CultureInfo">System.Globalization.CultureInfo</a>
 culture)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">return 1;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
Used in the View:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGrid.Columns</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:20px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">DataGridTextColumn</code>
<code style="color:#808080">Binding</code><code style="color:#000000">=</code><code style="color:blue">&quot;{Binding ., Converter={StaticResource rowfromobject}, StringFormat=#;;#}&quot;</code>
<code style="color:#808080">Header</code><code style="color:#000000">=</code><code style="color:blue">&quot;Via Converter&quot;</code><code style="color:#000000">/&gt;</code></span></span></div>
</div>
<p><br>
This rather complicates what would otherwise be a simple method but keeps the row viewmodel clean.</p>
<p>The second approach is demonstrated in the PersonVM viewmodel which is passed a reference to the CollectionView:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">class PersonVM : NotifyUIBase</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public Person ThePerson { get; set; }</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public CollectionView CV { get; set; }</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">public int RowNo</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">get</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">int row = -1;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">row = CV.IndexOf(this);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">return row &#43; 1;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
<p>In the RowNoViewModel we can see the CollectionView set in the row viewmodels and the bridging static:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">People = new ObservableCollection&lt;</code><code style="color:#006699; font-weight:bold">PersonVM</code><code style="color:#000000">&gt;(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:68px!important"><code style="color:#000000">ppl.OrderBy(x =&gt; x.ThePerson.OrganizationLevel)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:68px!important"><code style="color:#000000">.ThenBy(x =&gt; x.ThePerson.LastName).ThenBy(x
 =&gt; x.ThePerson.FirstName).Select(x =&gt; x).ToList());</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">PeopleView = (CollectionView)new CollectionViewSource { Source = People }.View;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000"><strong>ppl.ForEach(p =&gt;p.CV = PeopleView)</strong>;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000"><strong>CVHolder.CV = PeopleView;</strong></code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">RaisePropertyChanged(&quot;PeopleView&quot;);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">People.CollectionChanged &#43;= People_CollectionChanged;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">void People_CollectionChanged(object sender, <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Specialized.NotifyCollectionChangedEventArgs.aspx" target="_blank" title="Auto generated link to System.Collections.Specialized.NotifyCollectionChangedEventArgs">System.Collections.Specialized.NotifyCollectionChangedEventArgs</a> e)</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">RefreshView();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
Note also how the CollectionChanged event is handled. &nbsp; Insertion or deletion will fire this event and the CollectionView refresh will re-calculate the row numbers.<br>
<span style="font-size:12.1px">Raising the property changed even then tells the UI to read the values again. &nbsp;Explicitly handling inserts and deletes is usually best, but this approach is occasionally useful.<br>
<br>
</span></p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private object RefreshView()</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">PeopleView.Refresh();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">RaisePropertyChanged(&quot;PeopleView&quot;);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">return null;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>The user can also sort the DataGrid by clicking column headers - the DataGrid sorting event will be fired and this is handled in code behind. &nbsp;In order to keep the View and ViewModel de-coupled the View uses MVVM Light messaging to tell the ViewModel
 to refresh the CollectionView:</p>
<p>&nbsp;</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">private void dg_Sorting(object sender, DataGridSortingEventArgs e)</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var msg = new RefreshView();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Messenger.Default.Send&lt;</code><code style="color:#006699; font-weight:bold">RefreshView</code><code style="color:#000000">&gt;(msg);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
<br>
Registering for the message in the view model:<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">public RowNoViewModel()</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">GetData();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">InsertPerson = new RelayCommand&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;(ExecuteInsertPerson);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Messenger.Default.Register&lt;</code><code style="color:#006699; font-weight:bold">RefreshView</code><code style="color:#000000">&gt;(this,
 (action) =&gt; RefreshView());</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p><br>
<br>
</p>
<h2><a name="Further_Reading"></a><span style="color:#0070c0">Further Reading</span></h2>
<p><br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionview(v=vs.110).aspx">MSDN CollectionView</a><br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.listcollectionview(v=vs.110).aspx">MSDN ListCollectionView</a><br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionviewsource(v=vs.110).aspx">MSDN CollectionViewSource</a><br>
<a href="http://www.abhisheksur.com/2010/08/woring-with-icollectionviewsource-in.html">Working with CollectionView in WPF</a><br>
<a href="http://msdn.microsoft.com/en-us/library/gg405484(v=pandp.40).aspx">PRISM MVVM ( scroll down )</a><br>
<a href="http://wpftutorial.net/DataViews.html">WPF Tutorial</a><br>
<br>
<br>
</p>
<h2><a name="Closing"></a><span style="color:#0070c0">Closing</span></h2>
<p><br>
Many WPF developers only turn to the CollectionView for grouping. &nbsp;CollectionView offers some great functionality beyond this. The techniques described can solve fairly common requirements which are otherwise tricky without compromising MVVM principles.
 &nbsp;The sample keeps View and ViewModel totally decoupled and uses XAML friendly behaviors to avoid code behind.&nbsp;<br>
<br>
<br>
<br>
</p>
<p><br>
<img id="125965" src="http://i1.code.msdn.s-msft.com/collectionview-tips-mvvm-d6ebb4a7/image/file/125965/1/anithanks1.gif" alt="" width="471" height="156"><br>
<br>
</p>
