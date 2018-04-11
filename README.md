# XenoParse
A lightweight but efficient commandline argument parser with a highly simple usage.

### Efficient and flexible
XenoParse is capable of parsing commandline arguments of the current process and handle them properly.
You can add one or multiple argument definitions (synonymous meanings) on your own. Each argument will get its own callback function, which will get invoked once Parse(args) gets called.  

### Formatting argument definitions
Argument definitions will be passed through the function "AddAction". If you're planning to add multiple arguments with the same meaning, you can use the '|' seperator instead of calling "AddAction" all the time.

### Arguments with a parameter
Arguments might also require a parameter to perform some action. Once your callback function gets invoked, it will pass an object of 'XenoParseEventArgs' with the given parameter of the argument into the stack before entering the actual function body. Using the public property 'Value' from 'XenoParseEventArgs' will return you the parameter of your commandline argument.

### Arguments without a parameter
You can also add a "single" argument definition, which doesn't require an additional argument at all. Simply set the parameter "requiredExtraArgument" while passing the parameters to "AddAction" to false.

### Casts
The first parameter of your callback (type of 'object') can be casted safely to 'XenoParse'. The caller passes a this-reference of its own object to the sender parameter.  

### Screenshot
![alt text](https://i.gyazo.com/b2c8464c7d871deb03094b1ce2f9fd70.png)

## Leave credits, don't be a leecher. 
