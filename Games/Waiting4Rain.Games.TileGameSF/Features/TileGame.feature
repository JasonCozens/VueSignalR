Feature: TileGame

Scenario: Final Position
	Given the current position is:
	| Board	   |
	| T1 T2 T3 |
	| T4 T5 T6 |
	| T7 T8 __ |
	Then the board is:
	| Board	   |
	| T1 T2 T3 |
	| T4 T5 T6 |
	| T7 T8 __ |

Scenario: Free cell in centre, move right.
	Given the current position is:
	| Board	   |
	| T1 T2 T3 |
	| T4 __ T5 |
	| T6 T7 T8 |
	When I move a tile 'right'
	Then the board is:
	| Board	   |
	| T1 T2 T3 |
	| __ T4 T5 |
	| T6 T7 T8 |

Scenario: Free cell in centre, move up.
	Given the current position is:
	| Board	   |
	| T1 T2 T3 |
	| T4 __ T5 |
	| T6 T7 T8 |
	When I move a tile 'up'
	Then the board is:
	| Board	   |
	| T1 T2 T3 |
	| T4 T7 T5 |
	| T6 __ T8 |

Scenario: Free cell in centre, move left.
	Given the current position is:
	| Board	   |
	| T1 T2 T3 |
	| T4 __ T5 |
	| T6 T7 T8 |
	When I move a tile 'left'
	Then the board is:
	| Board	   |
	| T1 T2 T3 |
	| T4 T5 __ |
	| T6 T7 T8 |

Scenario: Free cell in centre, move down.
	Given the current position is:
	| Board	   |
	| T1 T2 T3 |
	| T4 __ T5 |
	| T6 T7 T8 |
	When I move a tile 'down'
	Then the board is:
	| Board	   |
	| T1 __ T3 |
	| T4 T2 T5 |
	| T6 T7 T8 |