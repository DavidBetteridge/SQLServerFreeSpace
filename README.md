# SQL Server Free Space Viewer

This tool allows you to visualise the free space in a SQL server database.

![Graph](graph.jpg "Graph")

First run the collect data option.  This will examine each of the GAM pages in your database to determine the number of unallocated extents.  This information will then be written to a binary file using protobuf.

Once the data file has been generated the view data option can be used.  This will plot a graph showing the space used in each GAM.  
Each red line in the graph represents 100 extents.  The higher the line the more data has been allocated.

Green shows the unallocated space.

White means the GAM doesn't exist.  This can appear at the end of the graph.


Glossary:
* Page - 8K worth of data
* Extent  - A set of 8 pages.
* GAM - 4GB worth of pages.

Limitations:
* Only databases with single files are supported.
