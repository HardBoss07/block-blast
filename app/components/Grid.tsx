"use client";

import {BASE_BG_BORDER_COLOR, CELL_SIZE, GRID_SIZE} from "@/types/consts";
import {Grid as G, GridCell} from "@/types/Grid";
import {initGridCells, placeBlockOnGrid} from "@/util/Game";
import {SBlock, SquareBlockSmall, TBlock} from "@/types/Blocks";

type Props = {
    grid?: G;
};

export default function Grid({grid}: Props) {
    // if no grid is provided, build a default one
    let displayGrid: G =
        grid ?? initGridCells({width: GRID_SIZE, height: GRID_SIZE, size: CELL_SIZE});

    displayGrid = placeBlockOnGrid(displayGrid, TBlock, 2, 2);
    displayGrid = placeBlockOnGrid(displayGrid, SBlock, 4, 4);
    displayGrid = placeBlockOnGrid(displayGrid, SquareBlockSmall, 0, 0);

    return (
        <div
            className="relative"
            style={{
                display: "grid",
                gridTemplateColumns: `repeat(${displayGrid.width}, ${displayGrid.size}px)`,
                gridTemplateRows: `repeat(${displayGrid.height}, ${displayGrid.size}px)`,
                gap: "2px",
                backgroundColor: "#444",
                position: "relative",
            }}
        >
            {displayGrid.cells?.flat().map((cell: GridCell) => (
                <div
                    key={`${cell.x}-${cell.y}`}
                    style={{
                        width: displayGrid.size,
                        height: displayGrid.size,
                        backgroundColor: cell.color,
                        border: `1px solid ${BASE_BG_BORDER_COLOR}`,
                    }}
                />
            ))}
        </div>
    );
}
