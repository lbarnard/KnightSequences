# KnightSequences
Knight Sequences

Run: KnightSequences.ConsoleOut for a console app which outputs the number of sequences for 10 key-presses

A few points about the approach.

This is obviously similar (as per the FAQ) to the standard Knight's Journey problem, so the obvious
choice was to represent the routes through the keypad as a tree structure.

The interesting part was the infinitely recursive nature of the keypad.  Which required some thought in its construction.

I eventually came up with a lazy loading 2-pass approach.  So the top level of the tree was constructed, then the lower valid moves were
wired up to their parent key (via the Key lookup);

Another aspect was that I wanted to make the keypad flexible and obvious, hence the use of
List<string[]> when constructing it, to give other developers/reviewers almost a direct graphical
representation of the keypad;

new[] {"A", "B", "C", "D", "E"},

new[] {"F", "G", "H", "I", "J"},

new[] {"K", "L", "M", "N", "O"},

new[] {null, "1", "2", "3", null}

I also chose to stick with a standard sized grid (rather than a jagged one) using nulls where appropriate
for non-valid/non-existing keys

TDD / Unit Tests / Refactoring for structure

I used tests to drive out a VERY simple version of the grid, so mocked out the keypad and node objects in order to test the following 
scenarios;

1 - Single Key = 0 Paths

2 - Two Keys, both not vowels = 1 Path

3 - Two Keys, one vowel = 0 Paths

Which satisfied me that my recursion and vowel checking was correct.

Object model: Keypad, which has a list of Keys

Performance problems.

I realised quite quickly that performance of the 32-key sequence would be a problem.  But I wanted to
ensure I had the correct logic first, so I created a component test, which ran for 10 key presses and then
locked in that behaviour via the test;

[TestCase(10, 2, 1013398)]

I then added test cases for 16 and 32.

Refactoring for performance.

I then started looking at performance, starting by stopping checking if each key is a vowel, and making the Node object
aware if it was itself a vowel.  Then I realised that I didn't have to store the sequence and could rely on the recursion algorithm
to not repeat any paths, finally remembering to keep the vowel count up to date.

This still wasn't brilliant, so I decided to use some PLINQ - and had fund and games with race conditions on the total (_walkCount)
and had a hunt on StackOverflow for some ideas, and found the Interlocked class, which prevents multiple
threads from updating the same ref object.

I'm still not happy with the performance, and I'm sure I could read-ahead more to avoid hitting routes with vowels
but I didn't want to spend too much time on that, as the question doesn't state any non-functional requirements.  It just
irked me that the 32-key sequence would have originally taken a few days (maybe longer) to process.

As it stands, on this PC (i7-2600S 2.80Ghz with 4Gb of RAM) the average times are as follows:

10-key sequence = 0.084 seconds

16-key sequence = 9 seconds 

32-key sequence = ...not run to completion yet.

The final performance gain took the 16-key sequence from 29 seconds down to approx. 9 seconds, but I thought I'd leave it there...the final part was looking at using PLINQ for the individual tree leaf searches, but that appears to 
introduce a lot of processor co-ordination overhead and feels a bit too much like using brute force to me.

Third-party libraries used (binaries included in the /lib directory)

nUnit
RhinoMocks

- Lee
