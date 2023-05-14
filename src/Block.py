class Block:
    def __init__(self, position: tuple = (0, 0), cells: list = []):
        '''
        Inicializador do bloco

        # Parâmetros
        ------------
        position: tuple
            Posição do bloco na matriz

        cells: list
            Lista de células que compõem o bloco
        '''
        self.position = position
        self.cells = cells
