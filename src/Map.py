import Block
from Cell import Cell, TYPE
import random

class Map:
    def __init__(self, rows: int, cols: int) -> None:
        '''
        Inicializador da classe

        Parâmetros:
        ----------
        rows: int
            Número de linhas do mapa

        cols: int
            Número de colunas do mapa
        '''

        self.map = [[Cell() for i in range(cols)] for j in range(rows)]

    def show(self):
        '''
        Mostra o mapa na tela
        '''
        for row in self.map:
            # print('|', end='')
            for cell in row:
                print(str(cell), end='')
            print()

    def can_insert_cell(self, position: tuple, _type=TYPE.MEDIUM):
        '''
        Verifica se é possível inserir um bloco na posição especificada

        Parâmetros:
        ----------
        position: tuple
            Posição a ser verificada

        Retorno:
        --------
        bool
            True se for possível inserir o bloco, False caso contrário
        '''
        if position[0] < 0 or position[1] < 0:
            return False
        if position[0] >= len(self.map[0]) or position[1] >= len(self.map):
            return False

        if _type == TYPE.HARD:
            identity = [
                [(-1, 0)],
                [(0, -1), (0, 0), (0, 1)],
                [(1, 0)]
            ]

            '''
            caso deseje que os quadrados difíceis não se toquem de nenhuma maneira:
            [(-1, -1), (-1, 0), (-1, 1)],
            [(0, -1), (0, 0), (0, 1)],
            [(1, -1), (1, 0), (1, 1)],

            caso os quadrados difíceis possam se tocar nas diagonais:
            [(-1, 0)],
            [(0, -1), (0, 0), (0, 1)],
            [(1, 0)],
            '''

            for row in identity:
                for current in row:
                    if self.map[position[1] + current[0]][position[0] + current[1]].type == TYPE.HARD:
                        return False

        return self.map[position[1]][position[0]].type == TYPE.EMPTY

    def insert_block(self, block: Block.Block):
        '''
        Insere um bloco no mapa

        Parâmetros:
        ----------
        block: Block.Block
            Bloco a ser inserido
        '''
        for row_index, row in enumerate(block.cells):
            for col_index, cell in enumerate(row):
                position_x = block.position[0] + col_index
                position_y = block.position[1] + row_index

                if not self.can_insert_cell((position_x, position_y), cell.type):
                    raise Exception('Can\'t insert block')

        for row_index, row in enumerate(block.cells):
            for col_index, cell in enumerate(row):
                position_x = block.position[0] + col_index
                position_y = block.position[1] + row_index
                self.map[position_y][position_x] = cell

    def generate_medium_block(self):
        orientation = random.choice(['horizontal', 'vertical'])
        _type = TYPE.MEDIUM

        could_insert = False
        insert_tries = 0
        while not could_insert:
            if orientation == 'horizontal':
                position_x = random.randint(0, len(self.map[0])-2)
                position_y = random.randint(0, len(self.map)-1)
                cells = [
                    [Cell(_type), Cell(_type)]
                ]
            else:
                position_x = random.randint(0, len(self.map[0])-1)
                position_y = random.randint(0, len(self.map)-2)
                cells = [
                    [Cell(_type)],
                    [Cell(_type)]
                ]

            block = Block.Block((position_x, position_y), cells)

            insert_tries += 1
            if insert_tries > 100:
                print('Máximo de tentativas excedido, ignorando bloco')
                return

            could_insert = True
            try:
                self.insert_block(block)
                could_insert = True
            except:
                could_insert = False

    def generate_hard_block(self):
        _type = TYPE.HARD

        could_insert = False
        insert_tries = 0
        while not could_insert:
            position_x = random.randint(0, len(self.map[0])-1)
            position_y = random.randint(0, len(self.map)-1)
            cells = [
                [Cell(_type), Cell(_type)],
                [Cell(_type), Cell(_type)]
            ]
            block = Block.Block((position_x, position_y), cells)

            insert_tries += 1
            if insert_tries > 100:
                print('Máximo de tentativas excedido, ignorando bloco')
                return

            could_insert = True
            try:
                self.insert_block(block)
                could_insert = True
            except:
                could_insert = False

    def fill_with_easy(self):
        for row_index, row in enumerate(self.map):
            for col_index, cell in enumerate(row):
                if cell.type == TYPE.EMPTY:
                    self.map[row_index][col_index] = Cell(TYPE.EASY)
