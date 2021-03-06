# ASP.NET MVC- AngularJS Treeview
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
- AngularJS
## Topics
- ASP.NET MVC
- TreeView
- AngularJS
## Updated
- 07/04/2016
## Description

<p>MVC&nbsp;application.&nbsp;AngularJS Treeview is a&nbsp;expandable node list that expand the child nodes whild selected.</p>
<ol>
<li><em>Compatible</em>: Safari, Chrome, Firefox, Opera, IE8, IE9 and mobile browsers (Android, Chrome Mobile, iOS Safari)
</li><li><em>Clone</em>:&nbsp;Use Git or checkout with SVN using the web&nbsp;<a href="https://github.com/eu81273/angular.treeview.git" target="_blank">URL</a>.
</li></ol>
<p><span id="more-3017">&nbsp;</span></p>
<p><em>Attributes of angular treeview are below.</em></p>
<ol>
<li>angular-treeview: the treeview directive. </li><li>tree-id : each tree&rsquo;s unique id. </li><li>tree-model : the tree model on $scope. </li><li>node-id : each node&rsquo;s id. </li><li>node-label : each node&rsquo;s label. </li><li>node-children: each node&rsquo;s children. </li></ol>
<p>Let&rsquo;s get started with visual studio, create a new MVC project to experiment.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/06/Spa_1.png"><img class="alignnone size-full x_x_wp-image-2998" src="http://shashangka.com/wp-content/uploads/2016/06/Spa_1.png" alt="Spa_1" width="635" height="99"></a></p>
<p>Install AngularJS and reference them to Layout page.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/06/tr_2.png"><img class="alignnone size-full x_x_wp-image-3021" src="http://shashangka.com/wp-content/uploads/2016/06/tr_2.png" alt="tr_2" width="791" height="173"></a></p>
<p>Let&rsquo;s create a method to get all data from server with api.</p>
<div class="crayon-syntax x_x_crayon-theme-classic x_x_crayon-font-monaco x_x_crayon-os-pc x_x_print-yes x_x_notranslate" id="crayon-577a8faac3356401006725">
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
<div class="crayon-num x_x_crayon-striped-num">18</div>
<div class="crayon-num">19</div>
<div class="crayon-num x_x_crayon-striped-num">20</div>
<div class="crayon-num">21</div>
<div class="crayon-num x_x_crayon-striped-num">22</div>
<div class="crayon-num">23</div>
<div class="crayon-num x_x_crayon-striped-num">24</div>
<div class="crayon-num">25</div>
<div class="crayon-num x_x_crayon-striped-num">26</div>
<div class="crayon-num">27</div>
<div class="crayon-num x_x_crayon-striped-num">28</div>
<div class="crayon-num">29</div>
<div class="crayon-num x_x_crayon-striped-num">30</div>
<div class="crayon-num">31</div>
<div class="crayon-num x_x_crayon-striped-num">32</div>
<div class="crayon-num">33</div>
<div class="crayon-num x_x_crayon-striped-num">34</div>
<div class="crayon-num">35</div>
<div class="crayon-num x_x_crayon-striped-num">36</div>
<div class="crayon-num">37</div>
<div class="crayon-num x_x_crayon-striped-num">38</div>
<div class="crayon-num">39</div>
<div class="crayon-num x_x_crayon-striped-num">40</div>
<div class="crayon-num">41</div>
<div class="crayon-num x_x_crayon-striped-num">42</div>
<div class="crayon-num">43</div>
<div class="crayon-num x_x_crayon-striped-num">44</div>
<div class="crayon-num">45</div>
<div class="crayon-num x_x_crayon-striped-num">46</div>
<div class="crayon-num">47</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a8faac3356401006725-1"><span class="crayon-c">// GET: api/Roles</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-2">
<span class="crayon-m">public</span><span class="crayon-h"> </span><span class="crayon-e">IHttpActionResult
</span><span class="crayon-e">GetRoles</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-3"><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-4">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">object</span><span class="crayon-sy">[</span><span class="crayon-sy">]</span><span class="crayon-h">
</span><span class="crayon-v">objRole</span><span class="crayon-h"> </span><span class="crayon-o">=</span><span class="crayon-h">
</span><span class="crayon-t">null</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-5"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">try</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-6">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-7"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">objRole</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-sy">(</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-8">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">from
</span><span class="crayon-e">rl </span><span class="crayon-st">in</span><span class="crayon-h">
</span><span class="crayon-v">db</span><span class="crayon-sy">.</span><span class="crayon-e">Roles</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-9"><span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">where
</span><span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">ParentID</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-h">
</span><span class="crayon-o">&amp;&amp;</span><span class="crayon-h"> </span>
<span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">Child</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-t">null</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-10">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">select</span><span class="crayon-h">
</span><span class="crayon-r">new</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-11"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-12">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">RoleID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">RoleID</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-13"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">RoleName</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">RoleName</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-14">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ParentID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">ParentID</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-15"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">Child</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">Child</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-16">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">collapsed</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-17"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">children</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-e">from
</span><span class="crayon-e">cl </span><span class="crayon-st">in</span><span class="crayon-h">
</span><span class="crayon-v">db</span><span class="crayon-sy">.</span><span class="crayon-e">Roles</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-18">
<span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">where
</span><span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">ParentID</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-v">rl</span><span class="crayon-sy">.</span><span class="crayon-v">RoleID</span><span class="crayon-h">
</span><span class="crayon-o">&amp;&amp;</span><span class="crayon-h"> </span>
<span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">Child</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-cn">1</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-19"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">select</span><span class="crayon-h">
</span><span class="crayon-r">new</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-20">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-21"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">RoleID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">RoleID</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-22">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">RoleName</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">RoleName</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-23"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ParentID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">ParentID</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-24">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">Child</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">Child</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-25"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">collapsed</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-26">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">children</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-e">from
</span><span class="crayon-e">cld </span><span class="crayon-st">in</span><span class="crayon-h">
</span><span class="crayon-v">db</span><span class="crayon-sy">.</span><span class="crayon-e">Roles</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-27"><span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">where
</span><span class="crayon-v">cld</span><span class="crayon-sy">.</span><span class="crayon-v">ParentID</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">RoleID</span><span class="crayon-h">
</span><span class="crayon-o">&amp;&amp;</span><span class="crayon-h"> </span>
<span class="crayon-v">cl</span><span class="crayon-sy">.</span><span class="crayon-v">Child</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-cn">1</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-28">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">select</span><span class="crayon-h">
</span><span class="crayon-r">new</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-29"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-30">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">RoleID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cld</span><span class="crayon-sy">.</span><span class="crayon-v">RoleID</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-31"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">RoleName</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cld</span><span class="crayon-sy">.</span><span class="crayon-v">RoleName</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-32">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ParentID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cld</span><span class="crayon-sy">.</span><span class="crayon-v">ParentID</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-33"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">Child</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">cld</span><span class="crayon-sy">.</span><span class="crayon-v">Child</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-34">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">collapsed</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">true</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-35"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-36">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-37"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">.</span><span class="crayon-e">ToArray</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-38">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-39"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">catch</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-i">Exception</span><span class="crayon-h">
</span><span class="crayon-v">e</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-40">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-41"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">e</span><span class="crayon-sy">.</span><span class="crayon-e">ToString</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-42">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-43"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-e">Json</span><span class="crayon-sy">(</span><span class="crayon-r">new</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-44">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-45"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-i">objRole</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3356401006725-46">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac3356401006725-47"><span class="crayon-sy">}</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p>Check the JSON result<a href="http://shashangka.com/wp-content/uploads/2016/06/tr_3.png"><img class="alignnone wp-image-3022 x_x_size-full" src="http://shashangka.com/wp-content/uploads/2016/06/tr_3.png" alt="tr_3" width="1343" height="63"></a></p>
<p>Here you can see our server is responding with data. Now let&rsquo;s bind this data to our UI to represent the tree.</p>
<p><strong>Angular Controller:</strong></p>
<div class="crayon-syntax x_x_crayon-theme-classic x_x_crayon-font-monaco x_x_crayon-os-pc x_x_print-yes x_x_notranslate" id="crayon-577a8faac336d826975159">
<div class="crayon-plain-wrap">&lt;textarea class=&quot;crayon-plain print-no&quot; readonly=&quot;readonly&quot;&gt;&lt;/textarea&gt;</div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
<div class="crayon-num x_x_crayon-striped-num">18</div>
<div class="crayon-num">19</div>
<div class="crayon-num x_x_crayon-striped-num">20</div>
<div class="crayon-num">21</div>
<div class="crayon-num x_x_crayon-striped-num">22</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a8faac336d826975159-1"><span class="crayon-sy">(</span><span class="crayon-t">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-2">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-3"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//angular module</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-4">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">var</span><span class="crayon-h">
</span><span class="crayon-v">myApp</span><span class="crayon-h"> </span><span class="crayon-o">=</span><span class="crayon-h">
</span><span class="crayon-v">angular</span><span class="crayon-sy">.</span><span class="crayon-e">module</span><span class="crayon-sy">(</span><span class="crayon-s">'myApp'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-sy">[</span><span class="crayon-s">'angularTreeview'</span><span class="crayon-sy">]</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-5">&nbsp;</div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-6">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//controller</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-7"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">myApp</span><span class="crayon-sy">.</span><span class="crayon-e">controller</span><span class="crayon-sy">(</span><span class="crayon-s">'myController'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-t">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">http</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-8">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">fetch</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-9"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">function</span><span class="crayon-h">
</span><span class="crayon-e">fetch</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-10">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-e">http</span><span class="crayon-sy">(</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-11"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">method</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'GET'</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-12">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">url</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'/api/Roles'</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-13"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">.</span><span class="crayon-st">then</span><span class="crayon-sy">(</span><span class="crayon-t">function</span><span class="crayon-h">
</span><span class="crayon-e">successCallback</span><span class="crayon-sy">(</span><span class="crayon-v">response</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-14">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">console</span><span class="crayon-sy">.</span><span class="crayon-e">log</span><span class="crayon-sy">(</span><span class="crayon-v">response</span><span class="crayon-sy">.</span><span class="crayon-v">data</span><span class="crayon-sy">.</span><span class="crayon-v">objRole</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-15"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">roleList</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">response</span><span class="crayon-sy">.</span><span class="crayon-v">data</span><span class="crayon-sy">.</span><span class="crayon-v">objRole</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-16">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-t">function</span><span class="crayon-h"> </span><span class="crayon-e">errorCallback</span><span class="crayon-sy">(</span><span class="crayon-v">response</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-17"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">console</span><span class="crayon-sy">.</span><span class="crayon-e">log</span><span class="crayon-sy">(</span><span class="crayon-v">response</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-18">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-19"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-20">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac336d826975159-21">&nbsp;</div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac336d826975159-22">
<span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>Html View:</strong></p>
<div class="crayon-syntax x_x_crayon-theme-classic x_x_crayon-font-monaco x_x_crayon-os-pc x_x_print-yes x_x_notranslate" id="crayon-577a8faac3371645982116">
<div class="crayon-plain-wrap"></div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a8faac3371645982116-1"><span class="crayon-sy">@</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-2">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span>ViewBag<span class="crayon-sy">.</span><span class="crayon-e">Title</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-s">&quot;Index&quot;</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-3"><span class="crayon-sy">}</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-4">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-5"><span class="crayon-r">&lt;h2&gt;</span><span class="crayon-i">Angular Treeview</span><span class="crayon-r">&lt;/h2&gt;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-6">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-7"><span class="crayon-r">&lt;div
</span><span class="crayon-e">ng-controller</span><span class="crayon-o">=</span><span class="crayon-s">&quot;myController&quot;</span><span class="crayon-h">
</span><span class="crayon-e">style</span><span class="crayon-o">=</span><span class="crayon-s">&quot;padding:20px;&quot;</span><span class="crayon-r">&gt;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-8">
<span class="crayon-i">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">&lt;span&gt;</span><span class="crayon-r">&lt;b&gt;</span><span class="crayon-i">Selected Node</span><span class="crayon-r">&lt;/b&gt;</span><span class="crayon-i"> : {{ngTree.currentNode.RoleName}}</span><span class="crayon-r">&lt;/span&gt;</span></div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-9"><span class="crayon-i">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">&lt;hr
</span><span class="crayon-r">/&gt;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-10">
<span class="crayon-i">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">&lt;div
</span><span class="crayon-e">data-angular-treeview</span><span class="crayon-o">=</span><span class="crayon-s">&quot;true&quot;</span></div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-11"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-e">data-tree-id</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ngTree&quot;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-12">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
<span class="crayon-e">data-tree-model</span><span class="crayon-o">=</span><span class="crayon-s">&quot;roleList&quot;</span></div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-13"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-e">data-node-id</span><span class="crayon-o">=</span><span class="crayon-s">&quot;RoleID&quot;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-14">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
<span class="crayon-e">data-node-label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;RoleName&quot;</span></div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-15"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-e">data-node-children</span><span class="crayon-o">=</span><span class="crayon-s">&quot;children&quot;</span><span class="crayon-r">&gt;</span></div>
<div class="crayon-line x_x_crayon-striped-line" id="crayon-577a8faac3371645982116-16">
<span class="crayon-i">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">&lt;/div&gt;</span></div>
<div class="crayon-line" id="crayon-577a8faac3371645982116-17"><span class="crayon-r">&lt;/div&gt;</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>Out Put:</strong><a href="http://shashangka.com/wp-content/uploads/2016/06/tr_4.png"><img class="alignnone size-full x_x_wp-image-3025" src="http://shashangka.com/wp-content/uploads/2016/06/tr_4.png" alt="tr_4" width="669" height="351"></a></p>
