
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title ACT Token
 * @notice A minimal ERC20 token with a simple Ether withdraw function.
 * @dev Implements transfer, approve, transferFrom. Owner can withdraw Ether sent to the contract.
 */
contract ACT {
    // --- ERC20 metadata ---
    string public name = "ACT Token";
    string public symbol = "ACT";
    uint8 public decimals = 18;

    // --- ERC20 storage ---
    uint256 public totalSupply;
    mapping(address => uint256) public balanceOf;
    mapping(address => mapping(address => uint256)) public allowance;

    // --- Ownership ---
    address public owner;

    // --- Events ---
    event Transfer(address indexed from, address indexed to, uint256 value);
    event Approval(address indexed owner, address indexed spender, uint256 value);
    event Withdraw(address indexed to, uint256 amount);

    // --- Constructor ---
    constructor(uint256 initialSupply) {
        owner = msg.sender;
        _mint(msg.sender, initialSupply);
    }

    // --- Core ERC20 ---
    function transfer(address to, uint256 value) external returns (bool) {
        _transfer(msg.sender, to, value);
        return true;
    }

    function approve(address spender, uint256 value) external returns (bool) {
        allowance[msg.sender][spender] = value;
        emit Approval(msg.sender, spender, value);
        return true;
    }

    function transferFrom(address from, address to, uint256 value) external returns (bool) {
        uint256 allowed = allowance[from][msg.sender];
        require(allowed >= value, "ERC20: allowance exceeded");
        // Decrease allowance
        allowance[from][msg.sender] = allowed - value;
        _transfer(from, to, value);
        return true;
    }

    // --- Ether handling ---
    receive() external payable {}
    fallback() external payable {}

    /**
     * @notice Withdraw Ether held by this contract to the owner.
     */
    function withdraw() external returns (bool) {
        require(msg.sender == owner, "Not owner");
        uint256 amount = address(this).balance;
        require(amount > 0, "No Ether to withdraw");
        (bool ok, ) = payable(owner).call{value: amount}("");
        require(ok, "Withdraw failed");
        emit Withdraw(owner, amount);
        return true;
    }

    // --- Internal helpers ---
    function _transfer(address from, address to, uint256 value) internal {
        require(to != address(0), "ERC20: transfer to zero address");
        uint256 fromBal = balanceOf[from];
        require(fromBal >= value, "ERC20: balance too low");
        unchecked {
            balanceOf[from] = fromBal - value;
            balanceOf[to] += value;
        }
        emit Transfer(from, to, value);
    }

    function _mint(address to, uint256 value) internal {
        require(to != address(0), "ERC20: mint to zero address");
        totalSupply += value;
        balanceOf[to] += value;
        emit Transfer(address(0), to, value);
    }
}
