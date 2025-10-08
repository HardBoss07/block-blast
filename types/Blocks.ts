export interface Block {
    color?: string,
    bitmap: string,
}

export type BlockType = | typeof TBlock | typeof SBlock | typeof SBlockReverse | typeof SquareBlockSmall | typeof SquareBlockBig;

export const TBlock: Block = {
    bitmap: '000\n010\n111',
}

export const SBlock: Block = {
    bitmap: '000\n110\n011',
}

export const SBlockReverse: Block = {
    bitmap: '000\n011\n110',
}

export const SquareBlockSmall: Block = {
    bitmap: '000\n110\n110',
}

export const SquareBlockBig: Block = {
    bitmap: '111\n111\n111',
}
