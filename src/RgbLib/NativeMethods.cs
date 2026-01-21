// Auto-generated C# bindings for rgb-lib
// This file contains P/Invoke declarations for the native rgb-lib C-FFI library

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

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_online(IntPtr obj);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_wallet(IntPtr obj);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_invoice(IntPtr obj);

        // ============================================
        // Wallet Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_new_wallet([MarshalAs(UnmanagedType.LPUTF8Str)] string wallet_data);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_generate_keys([MarshalAs(UnmanagedType.LPUTF8Str)] string bitcoin_network);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_restore_keys(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string bitcoin_network,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string mnemonic);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_go_online(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.Bool)] bool skip_consistency_check,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string electrum_url);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_address(IntPtr wallet);

        // ============================================
        // Balance Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_btc_balance(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_asset_balance(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id);

        // ============================================
        // UTXO Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_create_utxos(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.Bool)] bool up_to,
            byte num,
            uint size,
            float fee_rate,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_create_utxos_begin(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.Bool)] bool up_to,
            byte num,
            uint size,
            float fee_rate,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_create_utxos_end(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string signed_psbt);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_unspents(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.Bool)] bool settled_only,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        // ============================================
        // Asset Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_assets(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string filter_asset_schemas);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_issue_asset_nia(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string ticker,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
            byte precision,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string amounts);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_issue_asset_cfa(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string details,
            byte precision,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string amounts,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string file_path);

        // ============================================
        // Transfer Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResult rgblib_blind_receive(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id,
            ulong amount,
            uint duration_seconds,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string transport_endpoints,
            byte min_confirmations);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_send(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string recipient_map,
            [MarshalAs(UnmanagedType.Bool)] bool donation,
            float fee_rate,
            byte min_confirmations,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_send_begin(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string recipient_map,
            [MarshalAs(UnmanagedType.Bool)] bool donation,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string fee_rate,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string min_confirmations);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_send_end(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string signed_psbt,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_transfers(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_list_transactions(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_refresh(
            IntPtr wallet,
            IntPtr online,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string asset_id,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string filter,
            [MarshalAs(UnmanagedType.Bool)] bool skip_sync);

        // ============================================
        // Backup Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_backup(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string backup_path,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string password);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_backup_info(IntPtr wallet);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_restore_backup(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string backup_path,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string password,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string target_dir);

        // ============================================
        // Other Operations
        // ============================================

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_get_fee_estimation(
            IntPtr online,
            uint blocks);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CResultString rgblib_finalize_psbt(
            IntPtr wallet,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string unsigned_psbt);
    }

    // ============================================
    // Native Structs
    // ============================================

    [StructLayout(LayoutKind.Sequential)]
    public struct CResult
    {
        public IntPtr result;
        public IntPtr error;

        public bool IsSuccess => error == IntPtr.Zero;

        public string? GetError()
        {
            if (error == IntPtr.Zero) return null;
            return Marshal.PtrToStringUTF8(error);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CResultString
    {
        public IntPtr result;
        public IntPtr error;

        public bool IsSuccess => error == IntPtr.Zero;

        public string? GetResult()
        {
            if (result == IntPtr.Zero) return null;
            return Marshal.PtrToStringUTF8(result);
        }

        public string? GetError()
        {
            if (error == IntPtr.Zero) return null;
            return Marshal.PtrToStringUTF8(error);
        }
    }
}

