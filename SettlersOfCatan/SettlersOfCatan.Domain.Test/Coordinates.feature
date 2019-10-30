Feature: Coordinates

Scenario Outline: Getting neighbour hexagon's coordinates
	Given I have '<givenCoordinates.X>','<givenCoordinates.Y>', '<givenCoordinates.Z>' of a hexagon
	When I want to know the coordinates of the hexagon that lies <direction>
	Then the '<expectedCoordinates.X>','<expectedCoordinates.Y>','<expectedCoordinates.Z>' should be returned

	Examples:
		| givenCoordinates.X | givenCoordinates.Y | givenCoordinates.Z | direction | expectedCoordinates.X | expectedCoordinates.Y | expectedCoordinates.Z |
		| 0                  | 0                  | 0                  | West      | 0                     | -1                    | 1                     |
		| 0                  | 0                  | 0                  | East      | 0                     | 1                     | -1                    |
		| 0                  | 0                  | 0                  | NorthWest | 1                     | -1                    | 0                     |
		| 0                  | 0                  | 0                  | NorthEast | 1                     | 0                     | -1                    |
		| 0                  | 0                  | 0                  | SouthEast | -1                    | 1                     | 0                     |
		| 0                  | 0                  | 0                  | SouthWest | -1                    | 0                     | -1                    |