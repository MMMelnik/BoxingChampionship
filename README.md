# BoxingChampionship
Test task
##Using:
* ASP.NET MVC 5
* Entity Framework 
* JqGrid
##Pages' functuanality description:
* Home/Boxing Championship
represents a rank of fighters by "Rank" "Name" "Amount of battles"
Columns can be sorted by click on the column header
Also you can find a fighted using search field

* Page of championship
represents a list of buttles using JqGrid
(see ~/Scripts/myjqgrid.js)
search by "Winner's" or "Loser's" name is enabaled
(!!!)detailed view is enabeled by double-click
* Manage Battles
represents a list of buttles 
CRUD operations are supported
(defauls pages genarated by EF controller)
custom "details" view via jQuery UI
with "edit" reference
(see ~/Scripts/pop-upDetails.js)
