using System;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace RgbLib
{
    /// <summary>
    /// High-level wrapper for rgb-lib wallet operations
    /// </summary>
    public class RgbLibWallet : IDisposable
    {
        private IntPtr _walletPtr;
        private IntPtr _onlinePtr;
        private bool _disposed;

        /// <summary>
        /// Creates a new RGB wallet
        /// </summary>
        /// <param name="walletData">JSON wallet configuration</param>
        public RgbLibWallet(string walletData)
        {
            var result = NativeMethods.rgblib_new_wallet(walletData);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to create wallet");
            }
            _walletPtr = result.result;
        }

        /// <summary>
        /// Generate new keys for the specified Bitcoin network
        /// </summary>
        public static string GenerateKeys(string bitcoinNetwork)
        {
            var result = NativeMethods.rgblib_generate_keys(bitcoinNetwork);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to generate keys");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Restore keys from mnemonic
        /// </summary>
        public static string RestoreKeys(string bitcoinNetwork, string mnemonic)
        {
            var result = NativeMethods.rgblib_restore_keys(bitcoinNetwork, mnemonic);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to restore keys");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Go online and connect to electrum server
        /// </summary>
        public void GoOnline(string electrumUrl, bool skipConsistencyCheck = false)
        {
            EnsureNotDisposed();
            var result = NativeMethods.rgblib_go_online(_walletPtr, skipConsistencyCheck, electrumUrl);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to go online");
            }
            _onlinePtr = result.result;
        }

        /// <summary>
        /// Get a new address
        /// </summary>
        public string GetAddress()
        {
            EnsureNotDisposed();
            var result = NativeMethods.rgblib_get_address(_walletPtr);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to get address");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Get BTC balance
        /// </summary>
        public string GetBtcBalance(bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();
            var result = NativeMethods.rgblib_get_btc_balance(_walletPtr, _onlinePtr, skipSync);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to get BTC balance");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Get asset balance
        /// </summary>
        public string GetAssetBalance(string assetId)
        {
            EnsureNotDisposed();
            var result = NativeMethods.rgblib_get_asset_balance(_walletPtr, assetId);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to get asset balance");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Create UTXOs
        /// </summary>
        public string CreateUtxos(bool upTo = false, byte num = 1, uint size = 1000, float feeRate = 1.0f, bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();
            var result = NativeMethods.rgblib_create_utxos(_walletPtr, _onlinePtr, upTo, num, size, feeRate, skipSync);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to create UTXOs");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// List assets
        /// </summary>
        public string ListAssets(string? filterAssetSchemas = null)
        {
            EnsureNotDisposed();
            var result = NativeMethods.rgblib_list_assets(_walletPtr, filterAssetSchemas ?? "[]");
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to list assets");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Issue NIA (Non-Inflatable Asset)
        /// </summary>
        public string IssueAssetNia(string ticker, string name, byte precision, string amounts)
        {
            EnsureNotDisposed();
            EnsureOnline();
            var result = NativeMethods.rgblib_issue_asset_nia(_walletPtr, _onlinePtr, ticker, name, precision, amounts);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to issue NIA asset");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Begin send operation (returns unsigned PSBT)
        /// </summary>
        public string SendBegin(string recipientMap, bool donation = false, string? feeRate = null, string? minConfirmations = null)
        {
            EnsureNotDisposed();
            EnsureOnline();
            var result = NativeMethods.rgblib_send_begin(
                _walletPtr, 
                _onlinePtr, 
                recipientMap, 
                donation, 
                feeRate ?? "", 
                minConfirmations ?? "");
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to begin send");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// End send operation (broadcast signed PSBT)
        /// </summary>
        public string SendEnd(string signedPsbt, bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();
            var result = NativeMethods.rgblib_send_end(_walletPtr, _onlinePtr, signedPsbt, skipSync);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to end send");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// List transfers for an asset
        /// </summary>
        public string ListTransfers(string assetId)
        {
            EnsureNotDisposed();
            var result = NativeMethods.rgblib_list_transfers(_walletPtr, assetId);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to list transfers");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Refresh wallet state
        /// </summary>
        public string Refresh(string? assetId = null, string? filter = null, bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();
            var result = NativeMethods.rgblib_refresh(_walletPtr, _onlinePtr, assetId ?? "", filter ?? "", skipSync);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to refresh");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Backup wallet
        /// </summary>
        public string Backup(string backupPath, string password)
        {
            EnsureNotDisposed();
            var result = NativeMethods.rgblib_backup(_walletPtr, backupPath, password);
            if (!result.IsSuccess)
            {
                throw new RgbLibException(result.GetError() ?? "Failed to backup");
            }
            return result.GetResult() ?? throw new RgbLibException("Empty result");
        }

        private void EnsureNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(RgbLibWallet));
            }
        }

        private void EnsureOnline()
        {
            if (_onlinePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Wallet is not online. Call GoOnline() first.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_onlinePtr != IntPtr.Zero)
                {
                    NativeMethods.free_online(_onlinePtr);
                    _onlinePtr = IntPtr.Zero;
                }

                if (_walletPtr != IntPtr.Zero)
                {
                    NativeMethods.free_wallet(_walletPtr);
                    _walletPtr = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        ~RgbLibWallet()
        {
            Dispose(false);
        }
    }

    /// <summary>
    /// Exception thrown by rgb-lib operations
    /// </summary>
    public class RgbLibException : Exception
    {
        public RgbLibException(string message) : base(message) { }
    }
}

