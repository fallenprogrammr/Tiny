Tiny
====

A tiny C# class to handle arguments sent to a console application.

Tiny uses the power of dynamic and ExpandoObject in .Net 4 to dynamically populate name-value pairs from the arguments passed to the command line.

The inspiration from Tiny came from Rob Conery's Micro-Orm project - Massive, where he used the power of dynamic to display some really cool magic.


Tiny's argument parsing depends on separators for name-value pairs, for example if the command line for your app is:

c:\code\myapp\bin\myapp testargument1:testvalue testargument2:with_a:in_the_value testargument3

Note: The default separator for Tiny is ':'.

The code for parsing these arguments through Tiny is:

static void Main(string[] args)
{
    Tiny t = new Tiny(args);
}

You can read the passed arguments directly as properties via your code by writing code like this:

t.Arguments.testargument1
t.Arguments.testargument2

Any argument without a specified separator gets the name of UndefinedArgumentX where X is the number of the encountered argument without a separator.

In the above example, the last argument can be read via:

t.Arguments.UndefinedArgument1



