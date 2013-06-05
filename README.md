webstack
========

My personal stack of micro-libraries for web development.
Each of these libraries is available separately on http://nuget.org

bulky - High speed, lightweight bulk insert library for SQLite, MySQL, and SqlServer
container - A modified version of Munq that does not throw exceptions internally when resolving
dates - Handles date periods and occurrences (generally useful when billing)
depot - A caching interface, useful when moving from local to remote cache, uses remote metaphors
email - A library for handling delivery of email, in-process or parallelized in a service
hollywood - A governor shim that lets you control who can see your web app in production
linger - A simple delayed job queue, inspired by delayed_job, for performing tasks asynchronously
minirack - A manager for HttpModule-like behavior that can be easily plugged into a web app
minirack-routes - SEO-friendly canonical route manager with zero configuration
money - A small library to deal with calculating money and displaying it in different cultures
paging - A small library to handle scenarios for paging. Works with IQueryable too, but those are old news
table-descriptor - Maps objects and properties to database tables and columns; fast, flexible
tophat - Like Dapper, but for connection management. Gives any IDbConnection unit of work scoping
tuxedo - Like Dapper, but for common queries. Gives you high speed insert, update, delete with no SQL


Voltron Driven Development
--------------------------
Use one, use them all, use none. I don't believe in frameworks. Use purpose-built libraries that 
accomplish one and only one thing.
