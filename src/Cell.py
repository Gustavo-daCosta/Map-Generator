from colorama import Back, Fore, Style
from termcolor import colored

class TYPE:
    EMPTY = 0
    EASY = 1
    MEDIUM = 2
    HARD = 3


class Cell:
    def __init__(
        self,
        _type: TYPE = TYPE.EMPTY
    ):
        '''
        Inicializador do bloco

        # Parâmetros
        ----------
        _type: TYPE
            Tipo do bloco (vazio, fácil, médio, difícil)

        position: tuple
            Posição do bloco
        '''
        self.type = _type

    def __str__(self):
        if self.type == TYPE.EMPTY:
            return f"{Back.LIGHTGREEN_EX}{Fore.BLACK}{Style.BRIGHT} F {Style.RESET_ALL}"
        elif self.type == TYPE.EASY:
            return colored(' F ', 'black', 'on_green', ['bold'])
        elif self.type == TYPE.MEDIUM:
            return colored(' M ', 'black', 'on_yellow', ['bold'])
            # return f"{Back.YELLOW}{Fore.BLACK}{Style.BRIGHT} M {Style.RESET_ALL}"
        elif self.type == TYPE.HARD:
            return colored(' D ', 'black', 'on_light_red', ['bold'])
