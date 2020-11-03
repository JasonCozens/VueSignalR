Feature: TileGame

Scenario: Final Position
	Given the final position is:
	| ROW	   |
	| T1 T2 T3 |
	| T4 T5 T6 |
	| T7 T8 __ |
	Then the board is:
	| ROW	   |
	| T1 T2 T3 |
	| T4 T5 T6 |
	| T7 T8 __ |