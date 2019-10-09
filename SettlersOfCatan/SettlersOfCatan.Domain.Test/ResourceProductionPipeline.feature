Feature: ResourceProductionPipeline
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@ProducingResource
Scenario: Producing resource to the player without any resources
	Given a player
		| Name | Color |
		| Sam  | Red   |
	And without any resources
	And a village owner by the given player
	And a terrainType
		| TerrainType |
		| Hills       |
	When the ProduceResource method is being called with the given TerrainType on the village
	Then should be added to the player's resources.
		| ResourceType | Amount |
		| Brick        | 1      |

@ProducingResource
Scenario: Producing resource to the player with some resources
	Given a player
		| Name | Color |
		| Sam  | Red   |
	And some resources
		| key    | value |
		| Grain  | 3     |
		| Wool   | 4     |
		| Lumber | 6     |
	And a village owner by the given player
	And a terrainType
		| TerrainType |
		| Hills       |
	When the ProduceResource method is being called with the given TerrainType on the village
	Then the player should have the following resources
		| ResourceType | Amount |
		| Grain        | 3      |
		| Wool         | 4      |
		| Lumber       | 6      |
		| Brick        | 1      |