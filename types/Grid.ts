export interface Grid {
    width: number;
    height: number;
    size: number;
    cells?: GridCell[][];
}

export interface GridCell {
    color: string;
    x: number;
    y: number;
}