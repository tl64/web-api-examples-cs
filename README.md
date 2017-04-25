<h1><i> Web API examples</i></h1>
<img src="http://cybarlab.com/wp-content/uploads/2015/03/webapi.png" alt="not found" title="shaurma" align="left"/>
<p>A web API is an application programming interface (API) for either a web server or a web browser. It is a web development concept, usually limited to a web application's client-side (including any web frameworks being used), and thus usually does not include web server or browser implementation details such as SAPIs or web browser engine APIs unless publicly accessible by a remote web application.</p>
</br>
<p>Each app uses the same API to get, update and manipulate data. All apps have feature parity and when you need to make a change you just make it in one place in line with the ‘Don’t Repeat Yourself’ (DRY) principle of software development. The apps themselves then become relatively lightweight UI layers.</p>
<img src="https://cloud.githubusercontent.com/assets/25085025/25303971/8b01694a-276e-11e7-997e-8510cb31f802.PNG" alt="not found" title="qyabab"/>
<p>The REST architectural style has proven to be an effective way to leverage HTTP - although it is certainly not the only valid approach to HTTP.</p>
<p>REST stands for ‘Representational State Transfer’ and it is an architectural pattern for creating an API that uses HTTP as its underlying communication method. REST was originally conceived by Roy Fielding in his 2000 dissertation paper entitled ‘Architectural Styles and the Design of Network-based Software Architectures’.</p>
<span>Here are some principles applicable in REST-like applications:</span>
<ul type="circle">
<li><b>The state of a resource remains internal to the server, not the client</b> – The client can request it, or update it with requests made to the server.</li>
<li><b>No client context saved on the server between requests</b> – The server must not store the status of a client. Otherwise, this would break the scalability objective of REST when reaching a couple million users. Remember that requests can be distributed to several physical servers, which could cause physical resource consumption issues.</li>
<li><b>Client requests contain all information to service it</b> – No matter which request is sent by a client to a server, it must be complete enough for the server to process it.</li>
<li><b>Session states are stored on the client side</b> – If necessary, any information about the status of the communication between a logical server and a logical client must be held on the client side.</li>
<li><b>Multiple representations of a resource can coexist</b> – The chosen format used to represent the state of a resource in requests and responses is free (XML, JSON…). Multiple formats can be used.</li>
<li><b>Responses explicitly indicate their cacheability</b> – When a server returns a response to a request, the information it contains may or may not be cached by the client. If not, the client should make new requests to obtain the latest status of a resource, for example.</li>
<li><b>Code on Demand</b> – This is an optional feature in REST. Clients can fetch some extra code from the server to enrich their functionalities. An example is Javascript.</li>
</ul>
