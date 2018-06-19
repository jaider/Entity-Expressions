# Entity-Expressions
Create a Lambda Expression that map Entities to Model.

# Two Implementations
 * One is using Full Framework .NET 4.6 (`EntityExpressions\EntityExpressions.sln`)
 * The other is using .NET Core 2.0  (`EntityExpressionsCore\EntityExpressionsCore.sln`)

# Problem to solve
When we create a complex object from a Entity, e.g. Student that has a reference directly or indirectly to Courses, Grades, Teacher, etc. and it is kind of easy to create a StudentModel that has all of this property, but you have to use inline Lambda expression to get the efficient code/SQL as possible, such as: `DataContext.Students.Select(s => new StudentModel(){ ... Course = new CourseModel{ Name = s.Course.Name ...} }` and this is impossible to reuse.

With this library, you can Map property to property. It means that we can create a CourseModel from Course or StudentModel from Student, using in the model a `EntityExpressionAttribute` as you see in this demo solutions and all the lambda expression will be generated for you.

# Link
Additional, with AutoMapper you can also generate Expression Tree as well:
* http://automapper.readthedocs.io/en/latest/Queryable-Extensions.html
* http://automapper.readthedocs.io/en/latest/Understanding-your-mapping.html
* https://github.com/AutoMapper/AutoMapper.EF6

For example:
```csharp
var expression = context.Entities.ProjectTo<Dto>().Expression;
```
