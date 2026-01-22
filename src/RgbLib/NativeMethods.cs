// Auto-generated C# bindings for rgb-lib
// P/Invoke declarations for the native rgb-lib C-FFI library (ABI-matched)

using System;
using System.Runtime.InteropServices;

namespace RgbLib
{
    /// <summary>
    /// Native methods for rgb-lib C-FFI
    /// </summary>
    public static unsafe partial class NativeMethods
    {
        private const string LibraryName = "rgblibcffi";

        // ============================================
        // Memory Management
        // ============================================

        // Rust: pub extern "C" fn free_online(obj: COpaqueStruct)
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_online(COpaqueStruct obj);

        // Rust: pub extern "C" fn free_wallet(obj: COpaqueStruct)
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_wallet(COpaqueStruct obj);

        // Rust: pub extern "C" fn free_invoice(obj: COpaqueStruct)
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_invoice(COpaqueStruct obj);

        // NOTE: Highly recommended to add in Rust:
        // #[no_mangle] pub extern "C" fn rgblib_free_string(s: *mut c_char) { ... }
        // Then uncomment:
        // [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        // public static extern void rgblib_free_string(IntPtr s);

        // ============================================
        // Wallet Operations
        // ============================================

        // Rust: rgblib_new_wallet(wallet_data: *const c_char) -> CResult
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_new_wallet(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string wallet_data);

        // Rust: rgblib_generate_keys(bitcoin_network: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_generate_keys(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string bitcoin_network);

        // Rust: rgblib_restore_keys(bitcoin_network: *const c_char, mnemonic: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_restore_keys(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string bitcoin_network,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string mnemonic);

        // Rust: rgblib_go_online(wallet: &COpaqueStruct, skip_consistency_check: bool, electrum_url: *const c_char) -> CResult
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_go_online(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.I1)] bool skip_consistency_check,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string electrum_url);

        // Rust: rgblib_get_address(wallet: &COpaqueStruct) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_address(
            ref COpaqueStruct wallet);

        // ============================================
        // Balance Operations
        // ============================================

        // Rust: rgblib_get_btc_balance(wallet: &COpaqueStruct, online: *const COpaqueStruct, skip_sync: bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_btc_balance(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_get_asset_balance(wallet: &COpaqueStruct, asset_id: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_asset_balance(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id);

        // ============================================
        // UTXO Operations
        // ============================================

        // Rust: rgblib_create_utxos(wallet: &COpaqueStruct, online: &COpaqueStruct, up_to: bool, num_opt: *const c_char, size_opt: *const c_char, fee_rate: *const c_char, skip_sync: bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_create_utxos(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.I1)] bool up_to,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string num_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string size_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string fee_rate,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_create_utxos_begin(...) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_create_utxos_begin(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.I1)] bool up_to,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string num_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string size_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string fee_rate,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_create_utxos_end(wallet: &COpaqueStruct, online: &COpaqueStruct, signed_psbt: *const c_char, skip_sync: bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_create_utxos_end(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string signed_psbt,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_list_unspents(wallet: &COpaqueStruct, online: &COpaqueStruct, settled_only: bool, skip_sync: bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_unspents(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.I1)] bool settled_only,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // ============================================
        // Asset Operations
        // ============================================

        // Rust: rgblib_list_assets(wallet: &COpaqueStruct, filter_asset_schemas: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_assets(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string filter_asset_schemas);

        // Rust: rgblib_issue_asset_nia(wallet: &COpaqueStruct, ticker: *const c_char, name: *const c_char, precision: *const c_char, amounts: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_issue_asset_nia(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string ticker,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string precision,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string amounts);

        // Rust: rgblib_issue_asset_cfa(wallet: &COpaqueStruct, name: *const c_char, details_opt: *const c_char, precision: *const c_char, amounts: *const c_char, file_path_opt: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_issue_asset_cfa(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string details_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string precision,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string amounts,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string file_path_opt);

        // ============================================
        // Transfer Operations
        // ============================================

        // Rust: rgblib_blind_receive(wallet: &COpaqueStruct, asset_id_opt: *const c_char, assignment: *const c_char, duration_seconds_opt: *const c_char, transport_endpoints: *const c_char, min_confirmations: *const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_blind_receive(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string assignment,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string duration_seconds_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string transport_endpoints,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string min_confirmations);

        // Rust: rgblib_send(wallet:&COpaqueStruct, online:&COpaqueStruct, recipient_map:*const c_char, donation:bool, fee_rate:*const c_char, min_confirmations:*const c_char, skip_sync:bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_send(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string recipient_map,
            [MarshalAs(UnmanagedType.I1)] bool donation,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string fee_rate,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string min_confirmations,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_send_begin(...) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_send_begin(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string recipient_map,
            [MarshalAs(UnmanagedType.I1)] bool donation,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string fee_rate,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string min_confirmations);

        // Rust: rgblib_send_end(wallet:&COpaqueStruct, online:&COpaqueStruct, signed_psbt:*const c_char, skip_sync:bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_send_end(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string signed_psbt,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_list_transfers(wallet:&COpaqueStruct, asset_id_opt:*const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_transfers(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id_opt);

        // Rust: rgblib_list_transactions(wallet:&COpaqueStruct, online:&COpaqueStruct, skip_sync:bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_transactions(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // Rust: rgblib_refresh(wallet:&COpaqueStruct, online:&COpaqueStruct, asset_id_opt:*const c_char, filter:*const c_char, skip_sync:bool) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_refresh(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id_opt,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string filter,
            [MarshalAs(UnmanagedType.I1)] bool skip_sync);

        // ============================================
        // Backup Operations
        // ============================================

        // Rust: rgblib_backup(wallet:&COpaqueStruct, backup_path:*const c_char, password:*const c_char) -> CResult
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_backup(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string backup_path,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string password);

        // Rust: rgblib_backup_info(wallet:&COpaqueStruct) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_backup_info(
            ref COpaqueStruct wallet);

        // Rust: rgblib_restore_backup(backup_path:*const c_char, password:*const c_char, target_dir:*const c_char) -> CResult
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_restore_backup(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string backup_path,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string password,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string target_dir);

        // ============================================
        // Other Operations
        // ============================================

        // Rust: rgblib_get_fee_estimation(wallet:&COpaqueStruct, online:&COpaqueStruct, blocks:*const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_fee_estimation(
            ref COpaqueStruct wallet,
            ref COpaqueStruct online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string blocks);

        // Rust: rgblib_finalize_psbt(wallet:&COpaqueStruct, signed_psbt:*const c_char) -> CResultString
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_finalize_psbt(
            ref COpaqueStruct wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string signed_psbt);
    }

    // ============================================
    // Native Structs (ABI matched)
    // ============================================

    // Rust:
    // #[repr(C)] pub struct COpaqueStruct { ptr: *const c_void, ty: u64 }
    [StructLayout(LayoutKind.Sequential)]
    public struct COpaqueStruct
    {
        public IntPtr ptr;
        public ulong ty;
    }

    // Rust:
    // #[repr(C)] pub enum CResultValue { Ok, Err }
    public enum CResultValue : int
    {
        Ok = 0,
        Err = 1,
    }

    // Rust:
    // #[repr(C)] pub struct CResult { result: CResultValue, inner: COpaqueStruct }
    [StructLayout(LayoutKind.Sequential)]
    public struct CResult
    {
        public CResultValue result;
        public COpaqueStruct inner;

        public bool IsSuccess => result == CResultValue.Ok;
    }

    // Rust:
    // #[repr(C)] pub struct CResultString { result: CResultValue, inner: *mut c_char }
    [StructLayout(LayoutKind.Sequential)]
    public struct CResultString
    {
        public CResultValue result;
        public IntPtr inner;

        public bool IsSuccess => result == CResultValue.Ok;

        public string? GetResult()
        {
            if (!IsSuccess || inner == IntPtr.Zero) return null;
            return Marshal.PtrToStringUTF8(inner);
        }

        public string? GetError()
        {
            if (IsSuccess || inner == IntPtr.Zero) return null;
            return Marshal.PtrToStringUTF8(inner);
        }
    }
}
