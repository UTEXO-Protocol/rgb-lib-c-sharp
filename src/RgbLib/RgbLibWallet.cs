using System;

namespace RgbLib
{
    /// <summary>
    /// High-level wrapper for rgb-lib wallet operations
    /// </summary>
    public class RgbLibWallet : IDisposable
    {
        private COpaqueStruct _wallet;
        private COpaqueStruct _online;
        private bool _disposed;

        /// <summary>
        /// Creates a new RGB wallet
        /// </summary>
        /// <param name="walletData">JSON wallet configuration</param>
        public RgbLibWallet(string walletData)
        {
            var r = NativeMethods.rgblib_new_wallet(walletData);
            if (!r.IsSuccess)
            {
                throw new RgbLibException("Failed to create wallet");
            }

            _wallet = r.inner;
        }

        /// <summary>
        /// Generate new keys for the specified Bitcoin network
        /// </summary>
        public static string GenerateKeys(string bitcoinNetwork)
        {
            var r = NativeMethods.rgblib_generate_keys(bitcoinNetwork);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to generate keys");
            }
            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Restore keys from mnemonic
        /// </summary>
        public static string RestoreKeys(string bitcoinNetwork, string mnemonic)
        {
            var r = NativeMethods.rgblib_restore_keys(bitcoinNetwork, mnemonic);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to restore keys");
            }
            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Go online and connect to electrum server
        /// </summary>
        public void GoOnline(string electrumUrl, bool skipConsistencyCheck = false)
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_go_online(ref _wallet, skipConsistencyCheck, electrumUrl);
            if (!r.IsSuccess)
            {
                throw new RgbLibException("Failed to go online");
            }

            _online = r.inner;
        }

        /// <summary>
        /// Get a new address
        /// </summary>
        public string GetAddress()
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_get_address(ref _wallet);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to get address");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Get BTC balance
        /// </summary>
        public string GetBtcBalance(bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();

            var r = NativeMethods.rgblib_get_btc_balance(ref _wallet, ref _online, skipSync);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to get BTC balance");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Get asset balance
        /// </summary>
        public string GetAssetBalance(string assetId)
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_get_asset_balance(ref _wallet, assetId);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to get asset balance");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Create UTXOs
        /// NOTE: Rust ABI expects num/size/fee_rate as strings (num_opt/size_opt/fee_rate: *const c_char).
        /// So this method now takes strings. Pass "" to use defaults.
        /// </summary>
        public string CreateUtxos(
            bool upTo = false,
            string numOpt = "",
            string sizeOpt = "",
            string feeRate = "",
            bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();

            var r = NativeMethods.rgblib_create_utxos(ref _wallet, ref _online, upTo, numOpt, sizeOpt, feeRate, skipSync);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to create UTXOs");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// List assets
        /// </summary>
        public string ListAssets(string filterAssetSchemas = "[]")
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_list_assets(ref _wallet, filterAssetSchemas);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to list assets");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Issue NIA (Non-Inflatable Asset)
        /// NOTE: Rust ABI precision is string (*const c_char)
        /// </summary>
        public string IssueAssetNia(string ticker, string name, string precision, string amounts)
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_issue_asset_nia(ref _wallet, ticker, name, precision, amounts);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to issue NIA asset");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Begin send operation
        /// NOTE: Rust ABI fee_rate and min_confirmations are strings
        /// </summary>
        public string SendBegin(string recipientMap, bool donation = false, string feeRate = "", string minConfirmations = "")
        {
            EnsureNotDisposed();
            EnsureOnline();

            var r = NativeMethods.rgblib_send_begin(ref _wallet, ref _online, recipientMap, donation, feeRate, minConfirmations);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to begin send");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// End send operation
        /// </summary>
        public string SendEnd(string signedPsbt, bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();

            var r = NativeMethods.rgblib_send_end(ref _wallet, ref _online, signedPsbt, skipSync);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to end send");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// List transfers for an asset
        /// NOTE: Rust ABI takes asset_id_opt as string
        /// </summary>
        public string ListTransfers(string assetIdOpt = "")
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_list_transfers(ref _wallet, assetIdOpt);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to list transfers");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Refresh wallet state
        /// NOTE: Rust ABI asset_id_opt/filter are strings
        /// </summary>
        public string Refresh(string assetIdOpt = "", string filter = "", bool skipSync = false)
        {
            EnsureNotDisposed();
            EnsureOnline();

            var r = NativeMethods.rgblib_refresh(ref _wallet, ref _online, assetIdOpt, filter, skipSync);
            if (!r.IsSuccess)
            {
                throw new RgbLibException(r.GetError() ?? "Failed to refresh");
            }

            return r.GetResult() ?? throw new RgbLibException("Empty result");
        }

        /// <summary>
        /// Backup wallet
        /// Rust ABI returns CResult (no string payload). Return "OK" on success.
        /// </summary>
        public string Backup(string backupPath, string password)
        {
            EnsureNotDisposed();

            var r = NativeMethods.rgblib_backup(ref _wallet, backupPath, password);
            if (!r.IsSuccess)
            {
                throw new RgbLibException("Failed to backup");
            }

            return "OK";
        }

        private void EnsureNotDisposed()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(RgbLibWallet));
        }

        private void EnsureOnline()
        {
            if (_online.ptr == IntPtr.Zero)
                throw new InvalidOperationException("Wallet is not online. Call GoOnline() first.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (_online.ptr != IntPtr.Zero)
            {
                NativeMethods.free_online(_online);
                _online = default;
            }

            if (_wallet.ptr != IntPtr.Zero)
            {
                NativeMethods.free_wallet(_wallet);
                _wallet = default;
            }

            _disposed = true;
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
