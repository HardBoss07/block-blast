import {Grid, GridCell} from "@/types/Grid";
import {BASE_BG_COLOR} from "@/types/consts";

export function initGridCells({width, height, size}: Grid): Grid {
    const cells: GridCell[][] = [];

    for (let y = 0; y < height; y++) {
        const row: GridCell[] = [];
        for (let x = 0; x < width; x++) {
            row.push({
                x,
                y,
                color: BASE_BG_COLOR
            });
        }
        cells.push(row);
    }

    return {
        width,
        height,
        size,
        cells,
    };
}
