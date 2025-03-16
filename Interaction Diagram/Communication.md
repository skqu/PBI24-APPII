@startuml


rectangle ":A" as A
rectangle ":B" as B
rectangle ":C" as C
rectangle ":D" as D


A -right- B: 1b:b() \l -->
A -- C: 1c:c() \l -->
B -- C: 2b:b() \l <--
B -right- D: 1d.1:d() \l --> 
C -up- D: 2d.1:d() \l -->

@enduml

