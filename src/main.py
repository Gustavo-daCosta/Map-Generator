import Map
from Cell import Cell
from Block import Block

ROWS = 8
COLS = 16

HARD_COUNT = 8
MEDIUM_COUNT = 16

game_map = Map.Map(ROWS, COLS)


hard_block = Block(
    position=(1, 0),
    cells=[
        [Cell(3), Cell(3)],
        [Cell(3), Cell(3)]
    ],
)

for i in range(HARD_COUNT):
    game_map.generate_hard_block()


for i in range(MEDIUM_COUNT):
    game_map.generate_medium_block()

game_map.fill_with_easy()
game_map.show()
