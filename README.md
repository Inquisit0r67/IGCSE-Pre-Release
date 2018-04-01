# Some Information

The exam board have said that they will be looking mostly at the logic of the code in our exams and that syntax isn't scrutinized as much.
My code does use features we have not studied in our course, such as '**using System.Linq;**'. This with what we had been told before would have been unacceptable. However an assessment specialist has said:

>*"There is no single programmed solution to the tasks, the tasks have to be solved using a high-level procedural programming language    of your choice and they can all be undertaken using the requirements of the syllabus. However, candidates are free to use more advanced    programming techniques to enhance or refine their solutions if they wish. **Their work will be rewarded if the solution provided  solves    the   pre-release task and addresses the associated question**. It is likely that candidates within a given class will produce different    programmed solutions to the tasks and discussion between candidates and teacher is encouraged. **Candidates who explore the tasks and      find  different programmed ways of solving them tend to have a deeper understanding of why one way might be more suitable than another**    and consequently are able to provide more depth in their responses in the questions relating to the pre-release tasks on Paper 2. As      you will see in the Mark Schemes for previous papers, the answers shown are only one example of a suitable solution. **Other acceptable    programming methods and programming answers are given credit**."*

(Sir has put this statement on Teams btw.)

So in fact using different solutions using more programming techniques is sort of encouraged as it will increase your understanding of our pre release material in preparation for our exam on it.

> *"...As long as a candidate’s interpretation is supported by a logical approach that is appropriate to the task, the work is              rewarded."*

In short if your solution ticks all the boxes in the pre release requirement, it should be given credit. I recommend you attempt to find a solution using multiple methods, you should probably also do one that only uses the stuff we have learnt throughout the course to be on the safe side when you take the exam in the summer.

Good Luck:)

### Extra Info About Linq
Linq is a language integrated query component for all .NET languages (yes VB has this). It basically adds different querying capabilities. As programming languages become more Object Orientated Linq allows easier accessing and integration of stuff that does not use Object Orientated technology.

Usually for non-Object Orientated info you would use XML (extensible markup language) or Relational Databases.
This is how data is transferred and represented from the web and between different applications.
However Microsoft from their own words:

>*"Rather than add relational or XML-specific features to our programming languages and runtime, with the LINQ project we have taken a more general approach and are adding general-purpose query facilities to the .NET Framework that apply to all sources of information, not just relational or XML data. This facility is called .NET Language-Integrated Query (LINQ)."*

Its more universal and more readable for programmers that don't know Xquery and SQL. Developers can create queries in their code without having to learn another language.

#### Linq Stuff I Have Used
Lambda Function (**=>**) : This isn't specific to Linq only but it is used alot in it. It allows you to create functions that can be passed as arguments.

'**.Zip**' : This just applies a function to the elements of two sequences (list or array), it then produces the result.

'**.Take**' : This literally takes a range from a sequence.

'**.Skip**' : This skips a defined amount of elements in a sequence.

An example from my code:
>'**int[] Amount_sold = Stock.Zip(Running_Stock, (a, b) => a - b).ToArray();**'

This creates an array Amount_sold, the two sequences involved are Stock and Running_Stock. It makes them into variables a and b then applies the function of subtracting the two then converts it to an array and stores it as Amount_sold.

Hopefully this gives anyone who doesn't know what Linq is some understanding of what it is and what I used.
