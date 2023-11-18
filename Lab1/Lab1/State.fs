module Lab1.State

type cell =
    | Empty
    | Wall
    | Exit

type 'a matrix2d = 'a array array

type coordinate = int * int

type State = {
    height: int
    width: int
    field: cell matrix2d
    visited: bool matrix2d
}
