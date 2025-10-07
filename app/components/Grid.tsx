"use client";

import {CELL_SIZE, GRID_SIZE, BASE_BG_BORDER_COLOR} from "@/types/consts";
import {Grid as G, GridCell} from "@/types/Grid";
import {initGridCells} from "@/util/Game";

type Props = {
    grid?: G;
};

export default function Grid({grid}: Props) {
    // if no grid is provided, build a default one
    const displayGrid: G =
        grid ?? initGridCells({width: GRID_SIZE, height: GRID_SIZE, size: CELL_SIZE});

    return (
        <div
            className="relative"
            style={{
                display: "grid",
                gridTemplateColumns: `repeat(${displayGrid.width}, ${displayGrid.size}px)`,
                gridTemplateRows: `repeat(${displayGrid.height}, ${displayGrid.size}px)`,
                gap: "2px",
                backgroundColor: "#444",
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
