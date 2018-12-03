# Notes from Grading and reviewing Code Reviews

### 1. Should I use an expression body for a one-liner get?
  
I'd say that using an expression bodied property is optional based on programmer preference.  I would recommend you stay consistent within the file.  
The advantage of the expression bodied member is succinctness without reducing readability.  I like prefer it for this reason.  If I was writing a coding standard on this I would say, "CONSIDER using expression bodied property implementations for the most simple properties and methods.

### 2. Is it okay to set the default value explicitly even though it is redundant (e.g. `int Number {get;set;} = 0;`)?

Sure, especially if the default value is important.  I'd leave it to the programmers choice.  Generally when you aren't sure, readabilty should be the guide - keeping in mind that sometimes more code is less readable and sometimes less code is more readable.

### 3. What is the casing convention for fields?

Either `private DateTime _DateStart;` or `private DateTime _dateStart;` but be consistent throughout the project.  I (Mark Michaelis) prefer `_DateStart` because it means I only need to enter the name once for a field backed property.  (In class I showed how to update __snippets__ so that you could take advantage the approach I favor.)

### 4. Can I assign a method or property return to an implicitly typed local variable (`var`)

Hmmmm.... the Guideline is, "AVOID using implicitly typed local variables unless the data type of the assigned value is obvious."  What is the return type of the `SummaryInformation` method in `var data = SummaryInformation()` (whether a property or a method)?  If you can't tell, I suggest using the explicit rather than the implicit type.

### 5. Shoud I specify the message when instantiating a `ArgumentNullException`?

You should always identify the parameter name for which the exception is being thrown and you should do so using the `nameof` operator.  For property setters, use `nameof(value)`. However, there is generally no reason to also provide a message unless the message is adding value above and beyond the default message for an `ArgumentNullException`.  The general message, given a parameter name of data, is: "Value cannot be null. Parameter name: data"

### 6. When using pattern matching with a polymorphism (i.e. `UniversityCourse` derives from `Event` and either or both have a `GetSummaryInformation()` method) should I have _case_ statments for both types (i.e  `UniversityCourse` and `Event`). 

No.  If you have tests with pattern matching against `Event` and `UniversityCourse` you will notice that the most derived implementation is invoked such that you only need to have a case statement for `Event` assuming all it does is invoke `GetSummaryInformation()`.
In addition, be sure to check for null if that is a possible value.

### 7. Is it okay to change the value assigned in the setter of a property?

This is relatively unusual and possibly unexpected to the caller.  Use caution when changing the value.  When setting a value programmers expect the value the passed to be assigned. If you change it (invoke Trim() on a string for example) it might be unexpected behavior.  That doesn't mean don't, but you would certainly want to document this at a minimum.  If you don't want to allow pre/post fix spaces, consider throwing an exception instead.

### 8. Should I group all fields together and then all properties together or should they be intermingled so that each field appears with its' property.

I would stronly encourage the latter.  It isn't wrong to do it the other way but if you separate them then any changed to the property (such as the type or the name) would not be immediately obvious unless they were together.  Also, since fields should generally only be accessed from within their properties, the association (as though the field were part of the property definition) makes sense.

### 9. Is it okay to property which simply sets and gets a field with no additional logic (perhaps using expression bodies members) or should I use an automatically implemented property?

If the behavior is equivalent to an automatically implemented property then just use that.  To use anyything more adds clutter to the code without providing any value.

### 10. Given a `UniversityCourse` that derives from an `Event`, should I store an instance of the `Event` as a property on the `UniversityCourse`?

No.  What would be the point.  If you have an instance of the `UniversityCourse` you have an instance of the event.  You should not store the base class as a property (or field) on the derived class.  

### 11. Given a `UniversityCourse` that derives from an `Event`, should I explicity cast `UniversityCourse` to `Event`?

No!  `UniversityCourse` "is an" `Event` so no case is required and doing so doesn't provide value.  In fact, it adds clutter and causes readers to look a second time to see if there is something special going on.

### 12. What casing should I use for fields?

I prefer `_FieldName` but `_fieldName` is also acceptable.  Avoid `fieldName` as that overlaps with local variable conventions.

### 13. What casing should I use for properties?

Use PascalCase (e.g. `PropertyName`).  Avoid `propertyName` as that overlaps with local variable conventions.

### 14. If I use `string.Split()` but there is no separator within the string that is split, can I rely on the exception thrown when accessing the array returned from `Split()` to provide validation?

No, the exception thrown would be `IndexOutOfRangeException` which provides no information to the caller about what the problem was.  Instead, throw and `ArgumentException` that provides information to the caller about what to correct.

### 15. How do you invoke a Deconstrutor?

While you can obviously just call as a normal method, the point of the deconstructor is to return the values into a tuple as in
`        Person person = new Person("John", "Doe");
         (string firstName,string lastName) = person;`

### 16. Should all classes under test have a corresponding test class?

Generally, that is true.  You could follow a different convention that use tests callses for functionlity rather than per class but this wouldn't be common for small test projects were a one-to-one match from class under test to test class is the simplest.  If for example, you only tested `Application` from `CourseTests` and `EventTests` where would you test for an object that wasn't a `UniversityCourse` or and `Event`?

### 17. Is it okay to have a private or internal property that is never invoked?

Having an internal or private property that is never invoked doesn't make sense.  It just clutters the code, reduces your code coverage numbers, and adds no value.  Don't be afraid to delete code that isn't being used?

### 18. For properties (like `InstanceCount` whose value is maintained by the class that contains the property, should the access modifier be public or private?

Almost certainly it should be private.  Allowing another class to modify the values of the instance count exposes the property to having an invalid value.

### 18. Is it okay to have properties that are reference types and allow null.

Certainly... However, you need to be check for null befroe dereferencing. In general you should avoid allowing collection properties to be null.  This, of course, assumes that null is a valid value for the property.  Null, for example, for a person or events name is unlikely to be valid.

### 19. Should I keep track of `UniversityCourse` instances separately from `Event` instance count?

If `UniversityCourse` derives from `Event` then every time you create a `UniversityCourse` you would create an `Event`.  The result is that an instance counter in `Event` should be sufficient to count all instances of `Event`.  However, using the `Event`'s implementation of `InstanceCount` from `UniversityCourse` would not reflect the actual `UniversityCourse`'s instance count.  Thus, a separate counter is required.  What makes this difficult is that `Event`s instance count is available from `UniversityCourse` via inheritance making it confusing which one to use.  Another approach is probably to use the new modifier on the `UniversityCourse`'s instance count (but this is rare and no points were deducted if you didn't have this solution). However, this is only necessary if the base class has the same member as the derived class.

### 20. What exception type should be thrown when a value assigned to a property is not valid?

When assigned null and it isn't value use `ArgumentNullException`.  For values other than null, `ArgumentException` is generally correct unless another exception type will be more meaningful. You should never throw a `NullReferenceException`.

### 21. When is it okay to use `this`?  Is it okay, for example, to dereference a property using `this`, even though the instance property is available by its' name and no `this` qualifier?

Generally, avoid using `this` to avoid unnecessary clutter.  Assuming you naming conventions are solid, prefixing with `this` will not disambiguate and it is not adding any value.

### 22. Should all projects be of `OutputType` "Exe"?

No, doing so will force you to have a `Main` method even though main doesn't have any code.  For projects that are only defining an API and not actually needing a start, use a Library project instaed.

### 23. Is it okay to have a readonly property that is only set with a field initializer or a constant value?

No, if the value is always the same constant (hard coded) value, then you may as well declare the property as a constant.

### 24. Is it okay to have extra using directives even if they aren't ever used.

While mistakenly having one or two won't affect the behvior, they add clutter without value.  Having `using System.Threading.Tasks` but never using it misleads a reviewer into thinking they need to look out for synchronization issues for example.

### 25. Is it okay to have parameter names of a single letter?

Presumably you can come up with a better name so generally, no.  Use a word or set of words that provides more description on what the parameters/variable is used for.

### 26. What is the correct signature of a deconstructor?

A deconstructor is called Deconstruct, returns void, and takes only out parameters which.  E.g. 
`public void Deconstruct(
    out string directoryName, out string fileName, out string extension) {...}`
    
### 27. Given a `Get<propertyname>` and a `Set<propertyname>` methods, should refactoring into a property be used.

Yes, almost always unless you have a specific reason not to but it would be highly unusual (and having a static property would not justify the methods).  You should certainly not have both.  

### 28. Which is preferable, `string`, the key word, or `String` the .NET Type?

Generally use `string` but whichever you choose, be consistent throughout.  Don't use both.

### 29. Is it okay to have public fields?

Public, even protected fields should be avoided.  Just use properties or make the field private and wrap it with a property.

### 30. Should methods that don't access any instance data be static?

Yes, undoubtedly, even if they are private.

### 31. Could value in a property setter for a reference type be null?

Absolutely.  Therefore, either check for null and throw an exception or else be sure to check for null before dereferencing.

### 32. Is it okay to return from a property setter without changing the value even though a value was specified that was different than the current value?

No, this should be avoided.  If someone uses your API to set a property and you dont' sent the property but don't throw an exception, they user will think the property set was successful even though it wasn't.  You don't want to avoid surprising the user.  Especially since generally property setters are expected to be very basic and frequently not testsed.

### 33. Is it okay to use abbreviations for various names (classes, variables, etc.)?

Actually, you should avoid abbreviations unless you have decided it is common in the domain with which you are working and you use it consistently in all the code.  Consider creating a "glossary.md" file where you want to use abbreviations consistently.

### 34. When calling `text.Split()`, what happens if the search value doesn't exist?

Assuming the `text` is not null (which would throw an exception) or empty string, the result is an array of one item, the original value of text.  Therefore, there is not need to check for null or empty for the first item in the array (assuming `text` is not an empty string to start.  Furthermore, you need to check the `Count` on the array returned before accessing the second element of the array as it might not exist if the search value was not found.

### 35. How can I group all my properties into a collapsable group.

While not required (in fact they are occasionally controversial and accused of adding code clutter), you can use `#region`s.  No matter what, I would regions in favor of just commenting the grouping.

### 36. How should I store date time in .NET?

IF there is no change of a changes in timezone then use `DateTime`.  If you need to consider the timezone, then store the time in UTC - `DateTimeOffset`.  To store only the hour (not the minutes) for an event seems overly restrictive to when a class can start and stop.

### 37. Which is better for checking for null, `is null` or `== null`?

Generally they are identical, however, if the equality operator is overloaded, `is null` is preferable so always use `is null`.

### 38. What is the naming convention for items in a tuple?

Use PascalCase for tuple names and standard camelCase when declaring/using local variables in a tuple type syntax.

### 39. What is the correct casing for a parameter?

Parameters have the same scope as local variables and follow the same casing convention, camelCase.  This is especially important to avoid names that overlap with property names (which are PascalCase).

### 40. Should I wrap a static field with an instance property.

No.  If the property uses the static field as the backing store then the property should be static too.  A user of an instance property expects the data stored to be instance based if the property is instance based.

### 41. Can you keep track of instances of an object with an count increment in the constructor and a decrement in the deconstructor?

Yes. The destructur is accurate in decrementing the number of instances.  However the count may be seemingly off  as it might not be accurate in keeping the number of accessible/available instances since the garbage collector is indeterminate in when it cleans up the memory.  When implementing a destructor, remember you should probably implement the IDisposable pattern.
