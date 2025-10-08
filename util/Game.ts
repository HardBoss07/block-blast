import {Grid, GridCell} from "@/types/Grid";
import {BASE_BG_COLOR, BLOCK_COLORS} from "@/types/consts";
import {Block} from "@/types/Blocks";

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

export function placeBlockOnGrid(grid: Grid, block: Block, x: number, y: number): Grid {
    // shallow clone the grid and its rows
    const newGrid: Grid = {
        ...grid,
        cells: grid.cells ? grid.cells.map(row => [...row]) : [],
    };

    const color = block.color ?? BLOCK_COLORS[Math.floor(Math.random() * BLOCK_COLORS.length)];
    const rows = block.bitmap.trim().split("\n").map(r => r.split(""));

    const blockHeight = rows.length;
    const blockWidth = rows[0].length;

    for (let row = 0; row < blockHeight; row++) {
        for (let col = 0; col < blockWidth; col++) {
            const cellValue = rows[row][col];
            if (cellValue === "1") {
                const gridX = x + col;
                const gridY = y + (blockHeight - 1 - row); // flip vertically for bottom-left origin

                if (
                    gridX >= 0 &&
                    gridX < newGrid.width &&
                    gridY >= 0 &&
                    gridY < newGrid.height
                ) {
                    newGrid.cells![gridY][gridX].color = color;
                }
            }
        }
    }

    return newGrid;
}