Feature: MapCreator

Scenario: Generate map
	Given a BasicMapCreator
	When I call Create() on the BasicMapCreator
	Then the BasicMapCreator should return a SortedDictionary(Coordinates, Hexagon) sorted by coordinates in the following order
		| X  | Y  | Z  |
		| 2  | -2 | 0  |
		| 2  | -1 | 1  |
		| 2  | 0  | -2 |
		| 1  | -2 | 1  |
		| 1  | -1 | 0  |
		| 1  | 0  | -1 |
		| 1  | 1  | -2 |
		| 0  | -2 | 2  |
		| 0  | -1 | -1 |
		| 0  | 0  | 0  |
		| 0  | 1  | -1 |
		| 0  | 2  | -2 |
		| -1 | -1 | 2  |
		| -1 | 0  | 1  |
		| -1 | 1  | 0  |
		| -1 | 2  | -1 |
		| -2 | 0  | 2  |
		| -2 | 1  | 1  |
		| -2 | 2  | 0  |